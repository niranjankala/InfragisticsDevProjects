// JavaScript Document
(function($){
			$(window).load(function(){
				
				$(".auto-expand").mCustomScrollbar({axis:"yx", autoExpandScrollbar:true, advanced:{autoExpandHorizontalScroll:true}});
				
				$(".copy-body").mCustomScrollbar({axis:"y"});
				
				
				/*$(".disable-destroy a").click(function(e){
					e.preventDefault();
					var $this=$(this),
						rel=$this.attr("rel"),
						el=$(".copy-body"),
						output=$("#info > p code");
					switch(rel){
						case "toggle-disable":
						case "toggle-disable-no-reset":
							if(el.hasClass("mCS_disabled")){
								el.mCustomScrollbar("update");
								output.text("$(\".copy-body\").mCustomScrollbar(\"update\");");
							}else{
								var reset=rel==="toggle-disable-no-reset" ? false : true;
								el.mCustomScrollbar("disable",reset);
								if(reset){
									output.text("$(\".copy-body\").mCustomScrollbar(\"disable\",true);");
								}else{
									output.text("$(\".copy-body\").mCustomScrollbar(\"disable\");");
								}
							}
							break;
						case "toggle-destroy":
							if(el.hasClass("mCS_destroyed")){
								el.mCustomScrollbar();
								output.text("$(\".copy-body\").mCustomScrollbar();");
							}else{
								el.mCustomScrollbar("destroy");
								output.text("$(\".copy-body\").mCustomScrollbar(\"destroy\");");
							}
							break;
					}
				});*/
				
			});
		})(jQuery);