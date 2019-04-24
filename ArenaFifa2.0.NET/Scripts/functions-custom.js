function detectMobileDevice()
{
   var uagent = navigator.userAgent.toLowerCase();
   if (uagent.search("iphone") > -1 || uagent.search("mobile") > -1)
	  return 1;
   else
	  return 0;
}
function hidden_show_ObjectMobile(listOfObject, typeObject) {
	var arrayList = listOfObject.split(",");
	for (var i = 0; i<arrayList.length;i++) {
		document.getElementById(arrayList[i]).style.display = typeObject;
	}
}

function setContentHeightRegistration() {
        //$(".gentelella-right_col").css('min-height', $(window).height());

        var bodyHeight = $('body').outerHeight(),
            footerHeight = $('body').hasClass('footer_fixed') ? -10 : $("footer").height(),
            leftColHeight = $(".gentelella-left_col").eq(1).height() + $(".sidebar-footer").height(),
            contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

        // normalize content
        contentHeight -= $(".gentelella-nav_menu").height() + footerHeight + bodyHeight;

        $(".gentelella-right_col").css('min-height', contentHeight);
}


function activeSidebarMenu(pUrl) {
    var activePage = pUrl //pUrl.substring(pUrl.lastIndexOf('/') + 1);
	$("#sidebar-menu").find('a[href="' + activePage + '"]').parent('li').addClass('current-page');
	$("#sidebar-menu").find('a[href="' + activePage + '"]').attr("style", "color: #f0ad4e;font-weight:bold"); 
	$("#sidebar-menu").find('a[href="' + activePage + '"]').parent('li').parents('ul').slideDown(function() {
		setContentHeightRegistration();
	}).parent().addClass('active');
}
