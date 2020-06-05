/*****************************************************************************************************
Created By: Ferdous Md. Jannatul, Sr. Software Engineer
Created On: 10 December 2005
Last Modified: 13 April 2006
******************************************************************************************************/
//Generating Pop-up Print Preview page
function getPrint(print_area) {
    //Creating new page
    var pp = window.open();
    //Adding HTML opening tag with <HEAD> … </HEAD> portion 
    pp.document.writeln('<HTML><HEAD><title>INVOICE</title><link href="CSS/bootstrap.min.css" rel="stylesheet" /><!-- Font Awesome -->	<link href="CSS/font-awesome.min.css" rel="stylesheet" />	<!-- Endless -->    <link href="CSS/endless.min.css" rel="stylesheet" /></HEAD>');
    //pp.document.writeln('<LINK href=../_CSS/PrintStyle.css  type="text/css" rel="stylesheet" media="print"> <LINK href="../_CSS/main.css" rel="stylesheet" type="text/css"><base target="_self"></HEAD>');
    pp.document.writeln('<body MS_POSITIONING="GridLayout" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >');
    //Adding form Tag
    pp.document.writeln('<form  method="post">');
    //Creating two buttons Print and Close within a table
    //pp.document.writeln('<TABLE width=100% ><TR><TD></TD></TR><TR><TD align=center><table><tr><td><INPUT ID="PRINT" style="font-family:verdana;font-size:11px;font-weight:bold" type="button" value="Print" onclick="javascript:location.reload(true);javascript:hidePrint();javascript:ShowPrint()();"></td><td><INPUT ID="CLOSE" type="button" style="font-family:verdana;font-size:11px;font-weight:bold" value="Close" onclick="window.close();"></td></tr></table></TD></TR><TR><TD></TD></TR><TR><TD align=center>' + document.getElementById(print_area).innerHTML + '</TD><script type="text/javascript">javascript:hidePrint(); javascript:ShowPrint();</script></TR></TABLE>');
    pp.document.writeln('<TABLE width=100% ><TR><TD></TD></TR><TR><TD align=center></TD></TR><TR><TD></TD></TR><TR><TD align=center min style="border: 1px; min-height:700px;>' + document.getElementById(print_area).innerHTML + '</TD></TR></TABLE>');
    pp.document.writeln('</form></body></HTML>');
    document.getElementById(hfPrint).value = '<html><head><body><form>' + document.getElementById(print_area).innerHTML + '</form></body></head></html>';
}
//Generating Pop-up Print Preview page for Small Print
function getPrintsmall(print_area) {
    //Creating new page
    var pp = window.open();
    //Adding HTML opening tag with <HEAD> … </HEAD> portion 
    pp.document.writeln('<HTML><HEAD><title>INVOICE</title></HEAD>');
    //pp.document.writeln('<LINK href=../_CSS/PrintStyle.css  type="text/css" rel="stylesheet" media="print"> <LINK href="../_CSS/main.css" rel="stylesheet" type="text/css"><base target="_self"></HEAD>');
    pp.document.writeln('<body MS_POSITIONING="GridLayout" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" align="Center" >');
    //Adding form Tag
    pp.document.writeln('<form  method="post">');
    //Creating two buttons Print and Close within a table
    //pp.document.writeln('<TABLE width=100% ><TR><TD></TD></TR><TR><TD align=center><table><tr><td><INPUT ID="PRINT" style="font-family:verdana;font-size:11px;font-weight:bold" type="button" value="Print" onclick="javascript:location.reload(true);javascript:hidePrint();javascript:ShowPrint()();"></td><td><INPUT ID="CLOSE" type="button" style="font-family:verdana;font-size:11px;font-weight:bold" value="Close" onclick="window.close();"></td></tr></table></TD></TR><TR><TD></TD></TR><TR><TD align=center>' + document.getElementById(print_area).innerHTML + '</TD><script type="text/javascript">javascript:hidePrint(); javascript:ShowPrint();</script></TR></TABLE>');
    //pp.document.writeln('<TABLE width="30%"  align="center"><TR><TD></TD></TR><TR><TD align=center><INPUT ID="PRINT" style="font-family:verdana;font-size:11px;font-weight:bold" type="button" value="Print" onclick="javascript:location.reload(false);window.print();"><INPUT ID="CLOSE" type="button" style="font-family:verdana;font-size:11px;font-weight:bold" value="Close" onclick="window.close();"></TD></TR><TR><TD></TD></TR><TR><TD align=center; style="width:50px;" >' + document.getElementById(print_area).innerHTML + '</TD></TR></TABLE>');
    pp.document.writeln('<TABLE width="30%"  align="center"><TR><TD></TD></TR><TR><TD align=center></TD></TR><TR><TD></TD></TR><TR><TD align=center; style="width:50px;" >' + document.getElementById(print_area).innerHTML + '</TD></TR></TABLE>');
    pp.document.writeln('</form></body></HTML>');
}

