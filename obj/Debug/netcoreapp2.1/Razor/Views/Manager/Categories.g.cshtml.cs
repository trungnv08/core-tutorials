#pragma checksum "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Manager\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4658859605b8d3b3b9bbd8ac10b1d9c51957c23b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Categories), @"mvc.1.0.view", @"/Views/Manager/Categories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manager/Categories.cshtml", typeof(AspNetCore.Views_Manager_Categories))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\_ViewImports.cshtml"
using coreTutorials;

#line default
#line hidden
#line 2 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\_ViewImports.cshtml"
using coreTutorials.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4658859605b8d3b3b9bbd8ac10b1d9c51957c23b", @"/Views/Manager/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffbf74a590ef2f5dc4acde86cc8b91c19a786c38", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Manager\Categories.cshtml"
  
    ViewData["Title"] = "Categories";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(95, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(152, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Manager\Categories.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(242, 31, true);
            WriteLiteral("\r\n<h2>Category Manager</h2>\r\n\r\n");
            EndContext();
            BeginContext(274, 23, false);
#line 16 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Manager\Categories.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(297, 808, true);
            WriteLiteral(@"
<div class=""control-section"">
    <div class=""content-wrapper"">
        <button type=""button"" class=""btn btn-success"" tabindex=""1"" id='add' >Add</button>
        <div id=""Grid"">

        </div>
        <div class=""modal"" tabindex=""-1"" role=""dialog"" id=""viewModal"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">Product</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        ");
            EndContext();
            BeginContext(1105, 587, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fbbed78b484701846a8e0e61fd5cc5", async() => {
                BeginContext(1111, 574, true);
                WriteLiteral(@"
                            <div class=""form-group"">
                                <input class=""form-control"" id=""CategoryId"" name=""CategoryId"" data-bind=""value: CategoryId"" type=""hidden"" />
                            </div>
                            <div class=""form-group"">
                                <label class=""form-control"" for=""ProductName""> Category Name:</label>
                                <input class=""form-control"" id=""ProductName"" name=""Name"" data-bind=""textInput: Name"" />
                            </div>

                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1692, 7461, true);
            WriteLiteral(@"
                    </div>
                    <div class=""modal-footer"">
                        <button data-bind=""visible:(action()==0)"" id=""addCate"" class=""btn btn-success"">ADD</button>
                        <button data-bind=""visible:(action()==1)"" id=""updateCate"" class=""btn btn-primary"" click=""updateProduct()"">save</button>
                        <button data-bind=""visible:(action()==1)"" id=""deleteCate"" class=""btn btn-danger"">Remove</button>
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>

<script type=""text/javascript"">
    //#region variable define
    ej.grids.Grid.Inject(ej.grids.Selection, ej.grids.VirtualScroll, ej.grids.Sort, ej.grids.Filter, ej.grids.Edit, ej.grids.Toolbar);

    var option = {};
    var modal_Cate = {};
    var dd_source = {};

    var modalView = {
        action: ko.observable(0),
      ");
            WriteLiteral(@"  CategoryId: ko.observable(""""),
        Name: ko.observable("""")
    }
    ko.applyBindings(modalView);
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



    //#region grids
    //#region modal
    //event of ddl in modal
    function ddl_modal_select(args) {
        if (!args.itemData || (typeof args.itemData == typeof 'undefined')) {
            return;
        }
    }
    $('body').on('click', '#add', function () {
        modalView.action(0);
        $('#viewModal').modal('show');
    });
    $('body').on('click', '#addCate', function () {
        modal_Cate.CategoryId = """";
        modal_Ca");
            WriteLiteral(@"te.Name = modalView.Name();
        modal_Cate['_xsrf_token'] = getToken();
        $.ajax({
            type: 'POST',
            url: '/api/Categories/add',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(modal_Cate),
            success: function (res) {
                debugger;
                //var url = '/api/Categories/' + ddlModal.value;
                //grid.dataSource.dataSource.url = url;
                grid.refresh();
                $('#viewModal').modal('hide');
            }
        }).done();
    });
    $('body').on('click', '#updateCate', function () {
        modal_Cate.CategoryId = modalView.CategoryId();
        modal_Cate.Name = modalView.Name();
        modal_Cate['_xsrf_token'] = getToken();
        $.ajax({
            type: 'POST',
            url: '/api/Categories/update',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(modal_Cate)
   ");
            WriteLiteral(@"     }).done(function (res) {
            var url = '/api/Categories/' + ddlModal.value;
            grid.dataSource.dataSource.url = url;
            grid.refresh();
            $('#viewModal').modal('hide');
        });
    });
    $('body').on('click', '#deleteCate', function () {
        var modal = $('#viewModal');
        modal_Cate['_xsrf_token'] = getToken();
        $.ajax({
            type: 'POST',
            url: '/api/Categories/delete/' + modal.find(""#CategoryId"").val(),
            data: serialize(modal_Cate),
        }).done(function (res) {
            console.log(res);
            //reload grid data
            var url = '/api/Categories/' + ddlModal.value;
            grid.dataSource.dataSource.url = url;
            grid.refresh();
            modal.modal('hide');
            ko.cleanNode($('#viewModal'));
        });
    });


    //view action
    function viewClick(args) {
        var rowObj = grid.getRowObjectFromUID(args.target.closest('.e-row').getAttribu");
            WriteLiteral(@"te('data-uid'));
        var data = rowObj.data;
        //ddlModal.value = data.categoryId;
        modalView.CategoryId(data.CategoryId)
        modalView.Name(data.name);
        modalView.action(1);
        $('#viewModal').modal('show');

    }
    //#endregion



    //custom Adaptor
    class customAdaptor extends ej.data.UrlAdaptor {

        processQuery(dm, query, hierarchyFilters) {
            var obj = new ej.data.UrlAdaptor().processQuery(dm, query, hierarchyFilters),
                data = ej.data.DataUtil.parse.parseJson(obj.data),
                result = {
                };
            if (data.param) for (var i = 0; i < data.param.length; i++) {
                var param = data.param[i], key = Object.keys(param)[0];
                result[key] = param[key];
            }
            result.value = data
            var token = {};
            // addAntiForgeryToken(result);
            token._xsrf_token = getToken();
            var send = Object.keys(token).map(");
            WriteLiteral(@"function (k) {
                return encodeURIComponent(k) + '=' + encodeURIComponent(token[k])
            }).join('&');
            // debugger;
            return {
                type: ""POST"",
                data: send,
                url: dm.dataSource.url,
                pvtData: dm.adaptor.pvt,
                dataType: 'json',
                contentType: ""application/x-www-form-urlencoded; charset=UTF-8""
            }
        }
        processResponse(data, ds, query, xhr, request, changes) {
            request.data = JSON.stringify(data);
            console.log(data);
            return ej.data.UrlAdaptor.prototype.processResponse.call(this, data, ds, query, xhr, request, changes)
        }
    }
    var data_source = new ej.data.DataManager({
        url: '/api/Categories',
        requestType: ""POST"",
        adaptor: new customAdaptor()
    });
    var grid = new ej.grids.Grid({
        dataSource: data_source,
        // toolbar: ['Add', 'Edit', 'Delete', 'Update");
            WriteLiteral(@"', 'Cancel'],
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
        height: 480,
        columns: [
            {
                field: 'categoryId', visible: false, headerText: 'Category ID', isPrimaryKey: true, width: '130'
            },
            {
                field: 'name', headerText: 'Name', width: '200', clipMode: 'EllipsisWithTooltip',
                filter: { type: 'CheckBox' }
            }, {
                headerText: 'Commands', width: 120, commands: [{
         ");
            WriteLiteral(@"           buttonOption: { content: 'View', cssClass: 'e-primary', click: viewClick }
                }]
            }
        ],
        ClientSideEvents: function (args) {
            console.log(args);
        }

    });

    grid.appendTo(""#Grid"");

    //#endregion
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
