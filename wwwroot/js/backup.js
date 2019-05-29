//#region variable define
ej.grids.Grid.Inject(ej.grids.Selection, ej.grids.VirtualScroll, ej.grids.Sort, ej.grids.Filter, ej.grids.Edit, ej.grids.Toolbar);

var option = {};
var modal_Cate = {};
var dd_source = {};
var data_source = {};
var ddlModal = new ej.dropdowns.DropDownList({
    //bind the data manager instance to dataSource property
    dataSource: dd_source,
    //map the appropriate columns to fields property
    fields: { text: 'name', value: 'categoryId' },
    //set the placeholder to DropDownList input
    placeholder: "Select an Category",
    //sort the resulted items
    sortOrder: 'Ascending',
});




//add first
ddlModal.appendTo("#ddlModal");


//#endregion


//#region util function
//get xsrf token
function getToken() {
    return document.getElementsByName('_xsrf_token')[0].getAttribute('value');
}
//parse Object to urlencoded params
function serialize(data) {
    return Object.keys(data).map(function (k) {
        return encodeURIComponent(k) + '=' + encodeURIComponent(data[k])
    }).join('&');
};


//#endregion



//#region binding data to dropdown-list
//get dropdown-list data using ajax. store this using for dialog update

$.ajax({
    type: 'POST',
    url: '/api/Categories',
    data: serialize({ _xsrf_token: getToken() })
}).done(function (res) {
    dd_source = res['result'];

    ddlObject.dataSource = dd_source;
    ddlModal.dataSource = dd_source;

});

var ddlObject = new ej.dropdowns.DropDownList({
    //bind the data manager instance to dataSource property
    dataSource: dd_source,
    //map the appropriate columns to fields property
    fields: { text: 'name', value: 'categoryId' },
    //set the placeholder to DropDownList input
    placeholder: "Select an Category",
    //sort the resulted items
    sortOrder: 'Ascending',
    //event select ddl
    change: ddl_change_listener
});

//render the component
ddlObject.appendTo('#ddlelement');

//change event listener of dropdown list
function ddl_change_listener(args) {
    if (!args.itemData || (typeof args.itemData == typeof 'undefined')) {
        return;
    }
    var selected = args.itemData['categoryId'];
    $.ajax({
        type: 'POST',
        url: '/api/Products/' + selected,
        data: serialize({ _xsrf_token: getToken() })
    }).done(function (res) {
        grid.dataSource = res['result'];
    });
}

//#endregion





//#region grids
//#region modal
//event of ddl in modal
function ddl_modal_select(args) {
    if (!args.itemData || (typeof args.itemData == typeof 'undefined')) {
        return;
    }
    //modal_product.CategoryId = args.itemData['categoryId'];
}

$('body').on('click', '#updateProduct', function () {
    var modal = $('#viewModal');
    modal_Cate.ProductId = modal.find("#ProductId").val();
    modal_Cate.Name = modal.find("#ProductName").val();
    modal_Cate['_xsrf_token'] = getToken();
    $.ajax({
        type: 'POST',
        url: '/api/Products/update/' + modal_Cate.ProductId,
        data: serialize(modal_Cate),
    }).done(function (res) {
        $.ajax({
            type: 'POST',
            url: '/api/Products/' + ddlModal.value,
            data: serialize({ _xsrf_token: getToken() })
        }).done(function (res) {
            grid.dataSource = res['result'];
        });
        modal.modal('hide');
    });
});
$('body').on('click', '#deleteProduct', function () {
    $.ajax({
        type: 'POST',
        url: '/api/Products/delete/' + modal_Cate.ProductId,
        data: serialize(modal_Cate),
    }).done(function (res) {
        console.log(res);
        //reload grid data
        $.ajax({
            type: 'POST',
            url: '/api/Products/' + ddlModal.value,
            data: serialize({ _xsrf_token: getToken() })
        }).done(function (res) {
            grid.dataSource = res['result'];
        });
        modal.modal('hide');
        ko.cleanNode($('#viewModal'));
    });
});

//ko
function setData(args) {
    this.ProductId = args.productId;
    this.CategoryId = args.categoryId;
    this.Name = args.name;
}

//view action
function viewClick(args) {
    var rowObj = grid.getRowObjectFromUID(args.target.closest('.e-row').getAttribute('data-uid'));
    var data = rowObj.data;
    ddlModal.value = data.categoryId;
    $('#ProductId').val(data.productId);
    $('#ProductName').val(data.name);
    $('#viewModal').modal('show');

    //ko.applyBindings(setData(data));
    //console.log(data);
}
//#endregion





var grid = new ej.grids.Grid({
    dataSource: data_source,
    // toolbar: ['Add', 'Edit', 'Delete', 'Update', 'Cancel'],
    //actionBegin: _actionBegin,
    gridLines: 'Both',
    allowPaging: true,
    allowSelection: true,
    allowFiltering: true,
    allowSorting: true,
    ////editSettings: { allowEditing: true, allowAdding: true, allowDeleting: true },
    editSettings: { allowEditing: false, allowAdding: false, allowDeleting: false },
    enableVirtualization: true,
    filterSettings: { type: 'Menu' },
    selectionSettings: { persistSelection: true, type: 'Multiple', checkboxOnly: false },
    enableHover: true,
    height: 80,
    rowHeight: 38,
    load: () => {
        var rowHeight = grid.getRowHeight();  //height of the each row
        var gridHeight = grid.height;
        var pageSize = grid.pageSettings.pageSize;   //initial page size
        var pageResize = (gridHeight - (pageSize * rowHeight)) / rowHeight; //new page size is obtained here
        grid.pageSettings.pageSize = pageSize + Math.round(pageResize);
    },
    columns: [
        //{
        //    type: 'checkbox', allowFiltering: false, allowSorting: false, width: '60'
        //},
        {
            field: 'productId', visible: false, headerText: 'Product ID', isPrimaryKey: true, width: '130'
        },
        {
            field: 'name', headerText: 'Name', width: '200', clipMode: 'EllipsisWithTooltip',
            filter: { type: 'CheckBox' }
        }, {
            headerText: 'Commands', width: 120, commands: [{
                buttonOption: { content: 'View', cssClass: 'e-primary', click: viewClick }
            }]
        }
    ],
    ClientSideEvents: function (args) {
        console.log(args);
    }

});

grid.appendTo("#Grid");

    //#endregion