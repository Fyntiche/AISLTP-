$(function () {
    $("#jqGrid").jqGrid({
        url: "/Court/GetCourt",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'Название', 'Примечание',],
        colModel: [
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },
            { key: false, name: 'Txt', index: 'Txt', editable: true },
            { key: false, name: 'Prim', index: 'Prim', editable: true }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Записи о судах',
        emptyrecords: 'Нет записей о судах для отображения',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false,
    }).navGrid('#jqControls', {
        edit: true, add: true, del: true, search: true,
        searchtext: "Поиск суда", refresh: true
    },
        {
            zIndex: 100,
            url: '/Court/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Court/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Court/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Вы действительно хотите удалить эту запись?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            caption: "Поиск суда",
            sopt: ['cn']
        });
});


