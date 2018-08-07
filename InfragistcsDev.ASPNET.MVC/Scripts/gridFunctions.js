/*************************************************************
    FUNCTIONS 	    :	setrefervalue 
    ARGUMENTS		:  val, referid
    RETURN VALUE	:   Nill
    FUNCTION		:   This Function is used setValue from refer pop.
       
    *************************************************************/

function setrefervalue(val, referid) {
    ///debugger;

    if (val.length > 1) {
        var value = "";
        var text = "";
        var oldValue = "";
        var newValue = "";
        for (var i = 0; i < val.length; i++) {
            text = text + val[i].col1 + ",";
            value = value + val[i].col2 + ",";
        }
        if (referid.indexOf("|grid") < 0) {

            $('#refertext' + referid).val(text.substring(0, text.length - 1));
            $('#refertext' + referid).select();
            $('#refervalue' + referid).val(value.substring(0, value.length - 1));


            try { fnReferOnComplete(val, referid) } catch (e) { }

        }
        else {
            var gid = referid.split('|');

            $('#' + gid[0]).val(text);
            $('#' + gid[0]).next().val(val[0].col1);
            $('#' + gid[0]).select();


            $('div.ui-igpopover-close-button').click();


            try { fnReferOnComplete(val, referid) } catch (e) { }


        }
    }
    else {

        if (referid.indexOf("|grid") < 0) {

            $('#refertext' + referid).val(val[0].col1);
            $('#refertext' + referid).select();
            $('#refervalue' + referid).val(val[0].col2);

            try { fnReferOnComplete(val, referid) } catch (e) { }

        }
        else {
            var gid = referid.split('|');
            $('#' + gid[0]).val(val[0].col1);
            $('#' + gid[0]).next().val(val[0].col1);
            $('#' + gid[0]).select();

            $('div.ui-igpopover-close-button').click();

            try { fnReferOnComplete(val, referid) } catch (e) { }


        }
    }
}


/*************************************************************
    FUNCTIONS 	    :	Close 
    ARGUMENTS		:  no
    RETURN VALUE	:   Nill
    FUNCTION		:   This Function is used closeScreen.
       
    *************************************************************/


function Close() {

    if ($('#body').attr('class') == "content-body auto-expand-panel toggled") {
        $("#menu-toggle").click();
    }
    mainpage();
}


/*************************************************************
    FUNCTIONS 	    :	initializeFilters 
    ARGUMENTS		:   evt, ui, igGridName, maxLength, includeKeys
    RETURN VALUE	:   Nill
    FUNCTION		:   This Function is used setFiletr row of grid.
       
    *************************************************************/
function initializeFilters(evt, ui, igGridName, maxLength, includeKeys) {
    $("#" + igGridName).igGridFiltering("option", "filterDelay", 0);
    var isLocal = false;
    if (evt == null) {
        isLocal = true;
    }
    var lastExpression = null;
    function dataFilteringHandler(evt, ui) {
        //debugger;
        //  Capture the last filtering expression used in the grid.
        lastExpression = ui.newExpressions;

        //  Return false to prevent the grid from filtering.
        return false;
    }

    function editorKeyDownHandler(evt, ui) {
        //debugger;
        if (ui.key === 13) {
            //  Filter with the last saved expression.
            showloader();
            enableADD = true;
            IsFocusOnFistCell = true;

            if (typeof lastExpression == 'undefined' || lastExpression == null) {
                lastExpression = $("#" + igGridName).data('igGrid').dataSource.settings.filtering.expressions;
            }
            $("#" + igGridName).igGridFiltering("filter", lastExpression);
            if (isLocal) {
                hideloader();
                try { fnFilterComplete() } catch (e) { }
                $('#' + igGridName + '_container .ui-iggrid-filterrow.ui-widget td>div>div>span>input:eq(0)').focus();
            }

        }
    }




    //  Setup dataFiltering event handler.
    $("#" + igGridName).on("iggridfilteringdatafiltering", dataFilteringHandler);


    //  Loop through each of our filter editors.

    var maxLengthVal = maxLength.split('|');
    var includeKeysVal = includeKeys.split('|');
    $("input.ui-iggrid-filtereditor").parent().each(function (index) {
        // debugger;
        var editorType = $(this).data().editorType;
        /// debugger
        try {
            $(this).on(editorType.toLowerCase() + "keydown", editorKeyDownHandler);
            // $(this).on(editorType.toLowerCase() + "keypress", fnabc);
            //  Set the editor's maxLength option.
            ($(this)[$(this).data().editorType])("option", "maxLength", maxLengthVal[index]);
            ($(this)[$(this).data().editorType])("option", "toUpper", true);
            ($(this)[$(this).data().editorType])("option", "includeKeys", getCharSet(includeKeysVal[index]));
        }
        catch (e) {
            alert(e.message);

        }
    });
}





function disableFeatures(gridName) {

    $(".ui-iggrid-page").addClass("disabledPage");
    $("th[role='columnheader']").addClass("disabledHeader");
    $('#' + gridName + '_container .ui-iggrid-filterrow.ui-widget td>div>div>span>input').attr("disabled", true);
    $(".ui-iggrid-indicatorcontainer a").addClass("adisabled");
    $(".ui-iggrid-firstpage").addClass("disabledPage");
    $(".ui-iggrid-nextpage").addClass("disabledPage");
    $(".ui-iggrid-lastpage").addClass("disabledPage");
    $(".ui-iggrid-prevpage").addClass("disabledPage");
    $(".ui-iggrid-results").addClass("disabledPage");
    $(".ui-iggrid-pagelist").addClass("disabledPage");
    $(".ui-iggrid-headertext").addClass("disabledHeader");
    $("#" + gridName + "_pager").find('input, textarea, button, select').attr('disabled', true);
    $('.ui-iggrid-nextpagelabel').addClass('disabledHeader')
    $('.ui-igedit-button-common ui-unselectable ui-igedit-button-ltr ui-state-default ui-igedit-dropdown-button').addClass('disabledHeader');

}

function enableFeatures(gridName) {
    $("ui-iggrid-page").removeClass("disabledPage");
    $("th[role='columnheader']").removeClass("disabledHeader");
    $(".ui-iggrid-firstpage").removeClass("disabledPage");
    $(".ui-iggrid-nextpage").removeClass("disabledPage");
    $(".ui-iggrid-lastpage").removeClass("disabledPage");
    $(".ui-iggrid-prevpage").removeClass("disabledPage");
    $(".ui-iggrid-results").removeClass("disabledPage");
    $(".ui-iggrid-pagelist").removeClass("disabledPage");
    $('#' + gridName + '_container .ui-iggrid-filterrow.ui-widget td>div>div>span>input').attr("disabled", false);
    $(".ui-iggrid-indicatorcontainer a").removeClass("adisabled");
    $(".ui-iggrid-headertext").removeClass("disabledHeader");
    $("#" + gridName + "_pager").find('input, textarea, button, select').attr('disabled', false);
    $('.ui-iggrid-nextpagelabel').removeClass('disabledHeader')
    $('.ui-igedit-button-common ui-unselectable ui-igedit-button-ltr ui-state-default ui-igedit-dropdown-button').removeClass('disabledHeader');

}

function gridDelete(gridName) {
    var rows = $("#" + gridName).igGridSelection("selectedRows");
    var updates = $.extend({}, grid.data('igGrid').pendingTransactions());
    for (i = 0; i < rows.length; i++) {
        var pkValue = rows[i].id;
        //debugger;
        $("#" + gridName).igGridUpdating("deleteRow", pkValue);
        //if ('@User.UserInfo.ModifyAllow.ToUpper()' == 'Y') {
        //    $("#btn-ig-save").attr("disabled", false);
        //}
        $("#btn-ig-export").attr("disabled", true);
        // txtmode.value = '@WebApplication.GetAppResource("7963")';
        var button = $('<button class="gridundobtn">Undo</button>');

        $('table#' + gridName + '>tbody>tr[data-id="' + pkValue + '"]').append(button);
        $('table#' + gridName + '>tbody>tr[data-id="' + pkValue + '"]>button').attr('onclick', 'mclick("' + pkValue + '","' + gridName + '")');
        $('table#' + gridName + '>tbody>tr[data-id="' + pkValue + '"]').attr('onmouseover', 'mover("' + pkValue + '","' + gridName + '")');
        $('table#' + gridName + '>tbody>tr[data-id="' + pkValue + '"]').attr('onmouseout', 'mout("' + pkValue + '","' + gridName + '")');


        $.each(updates, function (index, transaction) {
            if (transaction.rowId == pkValue) {
                switch (transaction.type) {
                    case "newrow":

                        $.each(addedDeleteRow, function (index, transaction) {
                            if (transaction.rowId == pkValue) {
                                addedDeleteRow.splice(index, 1);

                            }

                        });

                        addedDeleteRow.push(transaction);

                        break;
                }
            }

        });

    }





    return false;
}


function mclick(item, gridName) {
    ///debugger;
    var updates = $.extend({}, grid.data('igGrid').pendingTransactions());

    $("#" + gridName).igGrid("rollback", item, true);


    $.each(updates, function (index, transaction) {
        if (transaction.rowId == item) {
            switch (transaction.type) {
                case "row":
                    grid.igGridUpdating('updateRow', transaction.rowId, transaction.row, null, false);
                    $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>td').addClass('updatetextcolor');
                    break;
                case "newrow":
                    grid.igGridUpdating('addRow', transaction.row, false);
                    $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>td').addClass('addtextcolor');
                    break;

            }
        }

    });


    $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>button').remove();
    if (addedDeleteRow != undefined) {
        $.each(addedDeleteRow, function (index, transaction) {
            if (transaction.rowId == item) {
                switch (transaction.type) {
                    case "newrow":
                        grid.igGridUpdating('addRow', transaction.row, false);
                        $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]').removeClass('ui-ig-altrecord ui-iggrid-altrecord ui-iggrid-modifiedrecord ui-iggrid-deletedrecord');
                        $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]').addClass('ui-ig-altrecord ui-iggrid-altrecord ui-iggrid-modifiedrecord');
                        $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>td').addClass('addtextcolor');
                        break;
                        // case "deleterow":
                        //    grid.igGridUpdating('deleteRow', transaction.rowId, false);
                        //   break;
                }
            }

        });
    }




}

function mover(item, gridName) {
    $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>button').show();
}
function mout(item, gridName) {
    $('table#' + gridName + '>tbody>tr[data-id="' + item + '"]>button').hide();
}