/*
 Функиция для создания, 
 редактирования и удаления данных
 */
$(function () {
    $("#jqGrid").jqGrid({
        url: "/Sotr/GetSotrs",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['Guid','Код сотрудника', 'Фамилия', 'Имя', 'Отчество', 'Дата рождения', 'Пол', 'Дата создания'],
        colModel: [
            { key: true, hidden: true, name: 'Guid', index: 'Guid', editable: true },  
            { key: false, name: 'Код сотрудника', index: 'Cod_sotr', editable: true },
            { key: false, name: 'Фамилия', index: 'Fio', editable: true },
            { key: false, name: 'Имя', index: 'Ima', editable: true },
            { key: false, name: 'Отчество', index: 'Otc', editable: true },
            { key: false, name: 'Дата рождени', index: 'Dr', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' } },
            { key: false, name: 'Пол', index: 'Sex', editable: true },
            { key: false, name: 'Дата создания', index: 'Dvi', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' } }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Список сотрудников',
        emptyrecords: 'Нет сотрудников для отображения',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Guid: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Sotr/Edit',
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
            url: "/Sotr/Create",
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
            url: "/Sotr/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Вы действительно хотите удалить эту запись?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});  