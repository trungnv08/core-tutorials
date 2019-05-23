function getCookie(cname) {
    var name = cname + "=";
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
    return "";
}

$.ajax({
    type: 'GET',
    headers: {
        "X-XSRF-TOKEN": getCookie("X-XSRF-TOKEN")
    },
    url: '/api/Users/',
}).done(function (res) {
    console.log(res);
    });
//debugger;
    //var _actionBegin = function (args) {
    //    console.log("_actionBegin: ");
    //    console.log(args);
    //    if (args.requestType == "save1") {
    //        if (args.action == "edit1") {
    //            data = args.rowData;
    //            $.ajax({
    //                type: 'PUT',
    //                url: '/api/Users/' + data.UserId,
    //                contentType: 'application/json',
    //                data: JSON.stringify(data),
    //            }).done(function (res) {
    //                console.log(res);
    //                //args.data = res.data;
    //            });
    //        } else if (args.action == "add") {
    //            data = args.data;
    //            $.ajax({
    //                type: 'POST',
    //                url: '/api/Users/',
    //                contentType: 'application/json',
    //                data: JSON.stringify(data),
    //            }).done(function (res) {
    //                console.log(res);
    //                //args.data = res.data;
    //            });
    //        }
    //    } else if (args.requestType == "delete1") {
    //        $.ajax({
    //            type: 'DELETE',
    //            url: '/api/Users/' + args.data.UserId,
    //        }).done(function (res) {
    //            console.log(res);
    //            //args.data = res.data;
    //        });
    //    }
    //};


var customAdaptor = new ej.UrlAdaptor().extend({
    //overriding the process query method for customization  
    processQuery: function (dm, query, hierarchyFilters) {
        var sorted = filterQueries(query.queries, "onSortBy"),
            grouped = filterQueries(query.queries, "onGroup"),
            filters = filterQueries(query.queries, "onWhere"),
            searchs = filterQueries(query.queries, "onSearch"),
            aggregates = filterQueries(query.queries, "onAggregates"),
            singles = filterQueryLists(query.queries, ["onSelect", "onPage", "onSkip", "onTake", "onRange"]),
            params = query._params,
            url = dm.dataSource.url, tmp, skip, take = null,
            op = this.options;

        var r = {
            sorted: [],
            grouped: [],
            filters: [],
            searches: [],
            aggregates: []
        };

        // calc Paging & Range  
        if (singles["onPage"]) {
            tmp = singles["onPage"];
            skip = getValue(tmp.pageIndex, query);
            take = getValue(tmp.pageSize, query);
            skip = (skip - 1) * take;
        } else if (singles["onRange"]) {
            tmp = singles["onRange"];
            skip = tmp.start;
            take = tmp.end - tmp.start;
        }

        // Sorting  
        for (var i = 0; i < sorted.length; i++) {
            tmp = getValue(sorted[i].e.fieldName, query);

            r.sorted.push(callAdaptorFunc(this, "onEachSort", { name: tmp, direction: sorted[i].e.direction }, query));
        }

        // hierarchy  
        if (hierarchyFilters) {
            tmp = this.getFiltersFrom(hierarchyFilters, query);
            if (tmp)
                r.filters.push(callAdaptorFunc(this, "onEachWhere", tmp.toJSON(), query));
        }

        // Filters  
        for (var i = 0; i < filters.length; i++) {
            r.filters.push(callAdaptorFunc(this, "onEachWhere", filters[i].e.toJSON(), query));

            for (var prop in r.filters[i]) {
                if (isNull(r[prop]))
                    delete r[prop];
            }
        }

        // Searches  
        for (var i = 0; i < searchs.length; i++) {
            tmp = searchs[i].e;
            r.searches.push(callAdaptorFunc(this, "onEachSearch", {
                fields: tmp.fieldNames,
                operator: tmp.operator,
                key: tmp.searchKey,
                ignoreCase: tmp.ignoreCase
            }, query));
        }

        // Grouping  
        for (var i = 0; i < grouped.length; i++) {
            r.grouped.push(getValue(grouped[i].e.fieldName, query));
        }

        // aggregates  
        for (var i = 0; i < aggregates.length; i++) {
            tmp = aggregates[i].e;
            r.aggregates.push({ type: tmp.type, field: getValue(tmp.field, query) });
        }

        var req = {};
        req[op.from] = query._fromTable;
        if (op.expand) req[op.expand] = query._expands;
        req[op.select] = singles["onSelect"] ? callAdaptorFunc(this, "onSelect", getValue(singles["onSelect"].fieldNames, query), query) : "";
        req[op.count] = query._requiresCount ? callAdaptorFunc(this, "onCount", query._requiresCount, query) : "";
        req[op.search] = r.searches.length ? callAdaptorFunc(this, "onSearch", r.searches, query) : "";
        req[op.skip] = singles["onSkip"] ? callAdaptorFunc(this, "onSkip", getValue(singles["onSkip"].nos, query), query) : "";
        req[op.take] = singles["onTake"] ? callAdaptorFunc(this, "onTake", getValue(singles["onTake"].nos, query), query) : "";
        req[op.where] = r.filters.length || r.searches.length ? callAdaptorFunc(this, "onWhere", r.filters, query) : "";
        req[op.sortBy] = r.sorted.length ? callAdaptorFunc(this, "onSortBy", r.sorted, query) : "";
        req[op.group] = r.grouped.length ? callAdaptorFunc(this, "onGroup", r.grouped, query) : "";
        req[op.aggregates] = r.aggregates.length ? callAdaptorFunc(this, "onAggregates", r.aggregates, query) : "";
        req["param"] = [];

        // Params  
        callAdaptorFunc(this, "addParams", { dm: dm, query: query, params: params, reqParams: req });

        // cleanup  
        for (var prop in req) {
            if (isNull(req[prop]) || req[prop] === "" || req[prop].length === 0 || prop === "params")
                delete req[prop];
        }

        if (!(op.skip in req && op.take in req) && take !== null) {
            req[op.skip] = callAdaptorFunc(this, "onSkip", skip, query);
            req[op.take] = callAdaptorFunc(this, "onTake", take, query);
        }
        var p = this.pvt;
        this.pvt = {};

        if (this.options.requestType === "json") {
            return {
                data: JSON.stringify(req),
                url: url,
                ejPvtData: p,
                type: "GET",  //Changing request type from POST to GET  
                contentType: "application/json; charset=utf-8"
            }
        }
        tmp = this.convertToQueryString(req, query, dm);
        tmp = (dm.dataSource.url.indexOf("?") !== -1 ? "&" : "/") + tmp;
        return {
            type: "GET",
            url: tmp.length ? url.replace(/\/*$/, tmp) : url,
            ejPvtData: p
        };
    },
    processResponse: ej.UrlAdaptor.prototype.processQuery // To customize the received response, you can modify here  
});

$("#viewLista").ejGrid({
    dataSource: ej.DataManager({
        url: 'http://data.mapion.com.br/000_-_000_-_Informações_Imoveis', adaptor: new customAdaptor(),
        headers: [{ "Range-Unit": "items", "Content-Range": '"' + pageSize - (pageIndex * pageSize) + '-' + pageIndex * pageSize + '"', "Prefer": "count=exact" }],
        allowScrolling: true,
        allowFiltering: true,
        allowPaging: true,

        ..............................................  
  
}).executeLocal(ej.Query());//.executeQuery(new ej.Query());//.executeLocal(ej.Query());  













    .extend({
        processQuery: function (dm, query, hierarchyFilters) {
            url = dm.dataSource.url;
            op = this.options;

            if(this.options.requestType === "json") {
    return {
        data: JSON.stringify(req),
        url: url,
        ejPvtData: p,
        type: "POST",  //Changing request type from POST to GET  
        contentType: "application/json; charset=utf-8"
    }
}
tmp = this.convertToQueryString(req, query, dm);
tmp = (dm.dataSource.url.indexOf("?") !== -1 ? "&" : "/") + tmp;
return {
    type: "GET",
    url: tmp.length ? url.replace(/\/*$/, tmp) : url,
    ejPvtData: p
};
            }
        })