
//function sort(sortBy) {
//    let isDesc = false;

//    var url_string = window.location.href;
//    var url = new URL(url_string);
//    var isDescUrlParam = url.searchParams.get("isDesc");
//    if (isDescUrlParam == "false") {
//        isDesc = true;
//    }

//    window.location.href = "/Customers/AllCustomers/?sortBy=" + sortBy + "&isDesc=" + isDesc;
//}

var Sortable = {
    baseUrl: '',
    sortBy: 0,
    searchTerm: '',
    //isDesc: false,

    Search() {
        var searchKey = $('#txtSearch').val();
        window.location.href = Sortable.baseUrl + searchKey;
    },
    Sort(sortBy) {
        window.location.href = Sortable.baseUrl +"?sortBy=" + sortBy;// "isDesc=" + Sortable.isDesc;
        //if (Sortable.isDesc == false) {
        //    Sortable.isDesc = true;
        //}
    }
};