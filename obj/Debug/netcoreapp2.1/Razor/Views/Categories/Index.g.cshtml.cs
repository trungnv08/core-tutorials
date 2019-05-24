#pragma checksum "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Categories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6db58a876a68553c5b0e7000437fd1e10cc9a64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Index), @"mvc.1.0.view", @"/Views/Categories/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Index.cshtml", typeof(AspNetCore.Views_Categories_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6db58a876a68553c5b0e7000437fd1e10cc9a64", @"/Views/Categories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffbf74a590ef2f5dc4acde86cc8b91c19a786c38", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Categories\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(145, 31, true);
            WriteLiteral("\r\n<h2>Category Manager</h2>\r\n\r\n");
            EndContext();
            BeginContext(177, 23, false);
#line 10 "D:\trung-sources\project\core-tutorials\core-tutorials\Views\Categories\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(200, 4733, true);
            WriteLiteral(@"
<div class=""control-section"">
    <div class=""content-wrapper"">
        <div id=""Grid"">
        </div>
    </div>

</div>
<script type=""text/javascript"">

    function getToken() {
        return document.getElementsByName('_xsrf_token')[0].getAttribute('value');
    }
    ej.grids.Grid.Inject(ej.grids.Selection, ej.grids.VirtualScroll, ej.grids.Sort, ej.grids.Filter, ej.grids.Edit, ej.grids.Toolbar);
    function getCookie(cname) {
        var name = cname + ""="";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return """";
    }
    var xsrf_token = getCookie(""X-XSRF-TOKEN"");
    var table = document.getElementById('datatable');
");
            WriteLiteral(@"
    //custom adaptor
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
            var send = Object.keys(token).map(function (k) {
                return encodeURIComponent(k) + '=' + encodeURIComponent(token[k])
            }).join('&');
            return {
                type: ""POST"",
                data: send,
                url: dm.dataSource.url,
                pvtData: dm.adap");
            WriteLiteral(@"tor.pvt,
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
        url: '/api/Users',
        insertUrl: ""api/Users"",
        removeUrl: ""api/Users/{UserId}"",
        requestType: ""POST"",
        adaptor: new customAdaptor()
    });

    var grid = new ej.grids.Grid({
        dataSource: data_source,
        toolbar: ['Add', 'Edit', 'Delete', 'Update', 'Cancel'],
        //actionBegin: _actionBegin,
        gridLines: 'Both',
        allowPaging: true,
        allowSelection: true,
        allowFiltering: true,
        allowSorting: true,
        editSettings: { allowEditing");
            WriteLiteral(@": true, allowAdding: true, allowDeleting: true },
        enableVirtualization: true,
        filterSettings: { type: 'Menu' },
        selectionSettings: { persistSelection: true, type: 'Multiple', checkboxOnly: true },
        enableHover: false,
        height: 600,
        rowHeight: 38,
        columns: [
            {
                type: 'checkbox', allowFiltering: false, allowSorting: false, width: '60'
            },
            {
                field: 'UserId', visible: false, headerText: 'User ID', isPrimaryKey: true, width: '130'
            },
            {
                field: 'Username', headerText: 'UserName', width: '200', clipMode: 'EllipsisWithTooltip',
                filter: { type: 'CheckBox' }
            },
            {
                field: 'FirstName', headerText: 'First Name', width: '200', clipMode: 'EllipsisWithTooltip',
                filter: { type: 'CheckBox' }
            },
            {
                field: 'LastName', headerText: 'Last Name',");
            WriteLiteral(@" width: '200', clipMode: 'EllipsisWithTooltip',
                filter: { type: 'CheckBox' }
            },
            {
                headerText: 'Active', width: '200', clipMode: 'EllipsisWithTooltip',
                template: '${FirstName} ${LastName}'
            },
            {
                field: 'LastName', headerText: 'Last Name', visible: false, width: '200', clipMode: 'EllipsisWithTooltip',
                filter: { type: 'CheckBox' }
            }


        ],
        ClientSideEvents: function (args) {
            console.log(args);
        }

    });

    grid.appendTo(""#Grid"");
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
