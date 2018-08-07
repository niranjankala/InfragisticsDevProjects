
function hideUnhideHeader(rptHeight,adjFactor) {
    
    if (document.getElementById("toggle").src.contains('hideHeader.png')) {
        $('#ctrlColapse').hide();
        $('#divReport').height((parseInt(rptHeight.replace('px', '')) + adjFactor) + 'px');
        var frame = $('#frmReport', window.parent.document);
        var height = jQuery("#frmReport").height();
       // alert(height);
       // alert(rptHeight)
        frame.height((parseInt(rptHeight.replace('px', '')) + adjFactor+13));
        document.getElementById("toggle").src = "../Images/showHeader.png";
    }
    else {
        $('#ctrlColapse').show();
        $('#divReport').height(rptHeight);
        var frame = $('#frmReport', window.parent.document);
        var height = jQuery("#frmReport").height();
       // alert(height);
        frame.height(height - adjFactor);

       // alert(jQuery("#frmReport").height());
        document.getElementById("toggle").src = "../Images/hideHeader.png";
    }

}

function Initialize_view(url) {
   /// debugger;
        showloader();
        $.ajax({
            url: url,
            cache: false,
            dataType: "html",
            success: function (data) {
                hideloader();
                $("#right").html(data);
            },
            error: function (data) {
            }
        });
    }

function checkUnhandledError(data)
{
  
    if (data.toString().contains('<div id="errorPage">')) {
        $("#right").html(data);
        hideloader();
        return true;
    }
    else
    {
        return false;
    }

}

function getCharSet(iCharSetIndex)
{
        var charSet = new Array();
        charSet[0] = "0123456789";																	    //Positive
        charSet[1] = "0123456789.";																	    //PositiveDecimal
        charSet[2] = "0123456789-";																	    //Negative
        charSet[3] = "0123456789.-";																    //NegativeDecimal
        charSet[4] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";						    //Alphabet
        charSet[5] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";                            //AlphabetSpace
        charSet[6] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; 		        
        charSet[7] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890-/_ ()[]+:";        //AlphabetNumericSpace Spl char 
        charSet[8] = "0123456789-/";																	 //Date
        charSet[9] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890-_,@.;-";		     //EMail
        charSet[10] = "0123456789- ()";																    //Phone (US Phone Numbers)
        charSet[11] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890-_.";			    //Passwords
        charSet[12] = "0123456789- :/";
        charSet[13] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890-/_";             //AlphabetNumeric 
        charSet[14] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_ ()+[]";         //Item Number  Spl char added IPS Req
        charSet[15] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_ ().,+[]";       //Company Name, Address Spl char added IP Req
        charSet[16] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";                //Curency Description
        charSet[17] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/_ .#&%"	        //WildCard Search Charset and Product Number
        charSet[18] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/_ .*()&#+";      //For Material Name
        charSet[19] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789, #->";           //MRP Exce Week
        charSet[20] = "0123456789- ,"	                                                                //MRP Exce Date
        charSet[21] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/_ .,#&";	        //Address Description
        charSet[22] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/_ . ";            // Alphanumeric with space and special characters              
        charSet[23] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,";                //AlphabetNumeric with Comma 
        charSet[24] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/_ .#&%()[]+:,@;*>\\"; //WildCard Search for All Text Type Column.
        charSet[25] = "0123456789";
        charSet[26] = "0123456789:";
        return charSet[iCharSetIndex];
   
}

function undoButtonCSS()
{ 

    var str={
        "display": "none",
        "color": "#fff",
        "background-color": "#ff0000",
        "position": "absolute",
        "z-index": "9999",
        "margin-top": "-3px",
        "padding": "2px",
        "right": "5px"
    };

    return str;
}

function getJqDateFormat(dateFormat) 
{
    var dateArr;
    var retVal;
    var sepChar;
    if (dateFormat.indexOf('-') > 0) {
        dateArr = dateFormat.split('-');
        sepChar = '-';
    }
    else {
        dateArr = dateFormat.split('/');
        sepChar = '/';
    }
    var icointer;
    retVal = '';
    for (icointer = 0; icointer < 3; icointer++) {
        switch (dateArr[icointer].toUpperCase()) {
            case "YYYY":
                retVal = retVal + 'yy' + sepChar
                break;
            case "MM":
                retVal = retVal + 'mm' + sepChar
                break;
            case "DD":
                retVal = retVal + 'dd' + sepChar
                break;
        }


    }
    retVal = retVal.substr(0, 8);

    return retVal;

}

function trimAll(strString)
{
    var strCopy = new String(strString);
    strCopy = strCopy.replace(/^\s+/, '');
    strCopy = strCopy.replace(/\s+$/, '');
    return strCopy.toString();
}


function validateDate(strDate, strDateFormat) {
    strDate = trimAll(strDate);
    if (strDate == '')
        return true;
    if (strDate.length == 10 || strDate.length == 8 || strDate.length == 9) { }
    else
        return false;
    var tempDate
    var strYear;     //Used For Year
    var strMonth;   // Used For Month
    var strDay;     // Used For Day
    var ValidLeapYearDay;
    var ValidLeapYearDay = true;
    var char;
    if (strDateFormat.indexOf('-') < 0)
        char = '/';
    else
        char = '-';

    // 'Getting Year, Month and day into Variables According to the Current Format

    switch (strDateFormat.substring(0, 1).toUpperCase()) {
        case 'D':
            tempDate = strDate.split(char);
            strDay = tempDate[0];
            strMonth = tempDate[1];
            strYear = tempDate[2];
            break;
        case 'M':

            tempDate = strDate.split(char);
            strMonth = tempDate[0];
            strDay = tempDate[1];
            strYear = tempDate[2];
            break;
        case 'Y':
            tempDate = strDate.split(char);
            strYear = tempDate[0];
            strMonth = tempDate[1];
            strDay = tempDate[2];


    }

    //'Now all the Validations for day, Month and Year shall be done
    strYear = trimAll(strYear);
    strMonth = trimAll(strMonth);
    strDay = trimAll(strDay);


    if (strMonth.substr(0, 1) == "0")
        strMonth = strMonth.substr(1, 1)

    if (strDay.substr(0, 1) == "0")
        strDay = strDay.substr(1, 1)


    if (isNaN(parseInt(strYear)))
        return false;
    if (parseInt(strYear) < 1900 || parseInt(strYear) > 3000)
        return false;

    // 'Month validations
    if (isNaN(parseInt(strMonth)))
        return false;
    if ((parseInt(strMonth) < 1) || (parseInt(strMonth) >= 13))
        return false;
    // 'Day validations
    if (isNaN(parseInt(strDay)))
        return false;

    if ((parseInt(strDay) >= 1) && (parseInt(strDay) <= 31)) {
        if ((parseInt(strMonth) == 4) || (parseInt(strMonth) == 6) || (parseInt(strMonth) == 9) || (parseInt(strMonth) == 11)) {
            if (parseInt(strDay) > 30)
                return false;
        }

        if ((parseInt(strMonth) == 2) && (parseInt(strDay) > 28)) {
            if (strDay > 29) {
                return false;
                ValidLeapYearDay = false;		//'Invalid Day but messgae sequence is controlled by this
            }
            if ((parseInt(strYear) % 4) != 0 && (parseInt(strDay) > 28)) {
                if ((parseInt(strYear) % 400) != 0 && (parseInt(strDay) > 29))
                    return false;
                ValidLeapYearDay = false;		//'Invalid Day but messgae sequence is controlled by this
            }

        }
    }
    else
        return false;

    if (ValidLeapYearDay) // ' This Flag is set in Day Validations
        return true;
    else
        return false;
}



function IsGreaterDate(strDate1, strDate2, strDateFormat) {
    var strYear1;     //Used For Year
    var strMonth1;   // Used For Month
    var strDay1;     // Used For Day

    var strYear2;     //Used For Year
    var strMonth2;   // Used For Month
    var strDay2;     // Used For Day
    var tmpArr1;
    var tmpArr2;
    var char;
    if (strDateFormat.indexOf('-') < 0)
        char = '/';
    else
        char = '-';

    // 'Getting Year, Month and day into Variables According to the Current Format

    tmpArr1 = strDate1.split(char);
    tmpArr2 = strDate2.split(char);

    switch (strDateFormat.substring(0, 1).toUpperCase()) {
        case 'D':
            {
                strYear1 = tmpArr1[2];
                strMonth1 = tmpArr1[1];
                strDay1 = tmpArr1[0];
                strYear2 = tmpArr2[2];
                strMonth2 = tmpArr2[1];
                strDay2 = tmpArr2[0];

                /*strYear1 = strDate1.substr(strDate1.length-4 , 4 );
                strMonth1 = strDate1.substr(3, 2);
                strDay1 = strDate1.substr(0, 2);
        
                strYear2 = strDate2.substr(strDate2.length-4 , 4 );
                strMonth2 = strDate2.substr(3, 2);
                strDay2 = strDate2.substr(0, 2);*/

                break;
            }
        case 'M':
            {
                 strYear1 = tmpArr1[2];
                strMonth1 = tmpArr1[0];
                strDay1 = tmpArr1[1];

                strYear2 = tmpArr2[2];
                strMonth2 = tmpArr2[0];
                strDay2 = tmpArr2[1];

                break;
            }
        case 'Y':
            {
                 strYear1 = tmpArr1[0];
                strMonth1 = tmpArr1[1];
                strDay1 = tmpArr1[2];

                strYear2 = tmpArr2[0];
                strMonth2 = tmpArr2[1];
                strDay2 = tmpArr2[2];

                break;
            }
    }

    strYear1 = trimAll(strYear1);
    strMonth1 = trimAll(strMonth1);
    strDay1 = trimAll(strDay1);

    strYear2 = trimAll(strYear2);
    strMonth2 = trimAll(strMonth2);
    strDay2 = trimAll(strDay2);

    if (strMonth1.substr(0, 1) == "0")
        strMonth1 = strMonth1.substr(1, 1);



    if (strDay1.substr(0, 1) == "0")
        strDay1 = strDay1.substr(1, 1);


    if (strMonth2.substr(0, 1) == "0")
        strMonth2 = strMonth2.substr(1, 1);

    if (strDay2.substr(0, 1) == "0")
        strDay2 = strDay2.substr(1, 1);


    if (parseInt(strYear1) > parseInt(strYear2))
        return true;

    if ((parseInt(strYear1) == parseInt(strYear2)) && (parseInt(strMonth1) > parseInt(strMonth2)))
        return true;

    if ((parseInt(strYear1) == parseInt(strYear2)) && (parseInt(strMonth1) == parseInt(strMonth2)) && (parseInt(strDay1) > parseInt(strDay2)))
        return true;

    
}



/*************************************************************
    FUNCTIONS 	    :	GetFormatedDate
	ARGUMENTS		:   strDate,strYearMonth,strDateFormat
	RETURN VALUE	:   Format date
	FUNCTION		:   This Function will set the date format according to format defined in configuration file
    *************************************************************/

function GetFormatedDate(strDay, strMonth, strYear, strDateFormat)
{
    var strDate;
    var char;
    if (strDateFormat.indexOf('-') < 0)
        char = '/';
    else
        char = '-';

    if ((strDay.toString()).length < 2) {
        strDay = '0' + strDay;
    }
    if ((strMonth.toString()).length < 2) {
        strMonth = '0' + strMonth;
    }

    switch (strDateFormat.substring(0, 1).toUpperCase()) {
        case 'D':
            {
                strDate = strDay + char + strMonth + char + strYear;
                break;
            }
        case 'M':
            {
                strDate = strMonth + char + strDay + char + strYear;
                break;
            }
        case 'Y':
            {
                strDate = strYear + char + strMonth + char + strDay;
                break;
            }
    }
    return strDate;
}

/*************************************************************
    FUNCTIONS 	    :	GetValidFormatedDate
    ARGUMENTS		:   strDate,strDateFormat
    RETURN VALUE	:   Formated Date
    FUNCTION		:   This Function is used to return full formated date.
                        eg. Input   1-1-2000  than Output 01-01-2000
    *************************************************************/
function GetValidFormatedDate(strDate, strDateFormat)
     {
    var strDay;
    var strMonth;
    var strYear;
    var tempDate;
    var char;
    if (strDateFormat.indexOf('-') < 0)
        char = '/';
    else
        char = '-';

    switch (strDateFormat.substring(0, 1).toUpperCase()) {
        case 'D':
            tempDate = strDate.split(char);
            strDay = tempDate[0];
            strMonth = tempDate[1];
            strYear = tempDate[2];
            break;
        case 'M':

            tempDate = strDate.split(char);
            strMonth = tempDate[0];
            strDay = tempDate[1];
            strYear = tempDate[2];
            break;
        case 'Y':
            tempDate = strDate.split(char);
            strYear = tempDate[0];
            strMonth = tempDate[1];
            strDay = tempDate[2];
    }
    return GetFormatedDate(strDay, strMonth, strYear, strDateFormat);
}


/*************************************************************
    FUNCTIONS 	    :	DateformatYMD
    ARGUMENTS		:   strDate,strDateFormat
    RETURN VALUE	:   Formated Date
    FUNCTION		:   This Function is used to return YMD formated date.
       
    *************************************************************/

function DateformatYMD(strDate, strDateFormat) {

    var strYear;     //Used For Year
    var strMonth;   // Used For Month
    var strDay;     // Used For Day
    var tmpArr;

    if (strDateFormat.indexOf('-') < 0)
        char = '/';
    else
        char = '-';

    tmpArr = strDate.split(char);

    switch (strDateFormat.substring(0, 1).toUpperCase()) {
        case 'D':
            {
                strYear = tmpArr[2];
                strMonth = tmpArr[1];
                strDay = tmpArr[0];


                break;
            }
        case 'M':
            {
                strYear = tmpArr[2];
                strMonth = tmpArr[0];
                strDay = tmpArr[1];



                break;
            }
        case 'Y':
            {
                strYear = tmpArr[0];
                strMonth = tmpArr[1];
                strDay = tmpArr[2];



                break;
            }
    }

    return strYear + char + strMonth + char + strDay;

}
/*************************************************************
    FUNCTIONS 	    :	dateDiff
    ARGUMENTS		:   strDate,endDate,strDateFormat
    RETURN VALUE	:   Formated Date
    FUNCTION		:   This Function is used to return number of days.
       
   
   
   *************************************************************/
function dateDiff(startDate, endDate, strDateFormat) {
     var start = new Date(DateformatYMD(startDate, strDateFormat)),
        end = new Date(DateformatYMD(endDate, strDateFormat)),

       diff = new Date(end - start),
        days = diff / 1000 / 60 / 60 / 24;

     
    return days;
}



/*************************************************************
    FUNCTIONS 	    :	ReportLoad 
    ARGUMENTS		:   strFilname
    RETURN VALUE	:   Nill
    FUNCTION		:   This Function is used to open report.
       
    *************************************************************/
function ReportLoad(strFilname) {
    if (strFilname != '')
        var m_WindowHandle = window.open(strFilname, 'New', 'location=no, toolbar=no, menubar=yes, resizable=yes, scrollbars=yes');
    try { m_WindowHandle.focus(); } catch (e) { }
}



/*************************************************************
    FUNCTIONS 	    :	MonthDiff
    ARGUMENTS		:   DateFrom, DateTo, Diff, DtFormat
    RETURN VALUE	:   Formated 1/2
    FUNCTION		:   This Function is used to get diffrence in month.
        
   *************************************************************/
function MonthDiff(DateFrom, DateTo, Diff, DtFormat) {
    var tempDateFirst, tempDateSecond;
    var objfirstDate, objSecondDate;

    objfirstDate =new Date( DateformatYMD(DateFrom, DtFormat));

    objSecondDate = new Date(DateformatYMD(DateTo, DtFormat));

    var objDate = new Date(objfirstDate.getFullYear(), objfirstDate.getMonth() + parseInt(Diff), objfirstDate.getDate());

    if (objDate > objSecondDate)
        return 1;
    else
        return 2;
}

/*************************************************************
    FUNCTIONS 	    :	YearDiff
    ARGUMENTS		:   DateFrom, DateTo, Diff, DtFormat
    RETURN VALUE	:   Formated 1 or 2
    FUNCTION		:   This Function is used to get diffrence in year.
        
   *************************************************************/
function YearDiff(DateFrom, DateTo, Diff, DtFormat) {
    var tempDateFirst, tempDateSecond;
    var objfirstDate, objSecondDate;

    objfirstDate = new Date(DateformatYMD(DateFrom, DtFormat));

    objSecondDate = new Date(DateformatYMD(DateTo, DtFormat));

    var objDate = new Date(objfirstDate.getFullYear() + parseInt(Diff), objfirstDate.getMonth(), objfirstDate.getDate());

    if (objDate > objSecondDate)
        return 1;
    else
        return 2;
}
