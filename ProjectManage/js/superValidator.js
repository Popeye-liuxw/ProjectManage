//***********************************************************
//����ԭ����֤��ܽ��иĽ�
//ʹ��ʱ����Ҫ��Ҫ������֤�ı�ǩ����check����
//��check="1"��ʱ��,����¼��Ϊ��,����������ݾͰ�reg���԰󶨵������������֤.
//��check="2"��ʱ��,��ֱ�Ӱ���reg�󶨵�������ʽ������֤.
// code by lxs QQ253204
//***********************************************************
//���������Ҫ��֤�ı�ǩ
(function($){
	$(document).ready(function(){
		$('select[tip],select[check],input[tip],input[check],textarea[tip],textarea[check]').tooltip();
	});
})(jQuery);

(function($) {
    $.fn.tooltip = function(options){
		var getthis = this;
        var opts = $.extend({}, $.fn.tooltip.defaults, options);
		//������ʾ��
        $('body').append('<table id="tipTable" class="tableTip"><tr><td  class="leftImage"></td> <td class="contenImage" align="left"></td> <td class="rightImage"></td></tr></table>');
		//�ƶ�������ظմ�������ʾ��
        $(document).mouseout(function(){$('#tipTable').hide()});
		
        this.each(function(){
            if($(this).attr('tip') != '')
            {
                $(this).mouseover(function(){
                    $('#tipTable').css({left:$.getLeft(this)+'px',top:$.getTop(this)+'px'});
                    $('.contenImage').html($(this).attr('tip'));
                    $('#tipTable').fadeIn("fast");
                },
                function(){
                    $('#tipTable').hide();
                });
            }
            if($(this).attr('check') != '')
            {
				
                $(this).focus(function()
				{
                    $(this).removeClass('tooltipinputerr');
                }).blur(function(){
                    if($(this).attr('toupper') == 'true')
                    {
                        this.value = this.value.toUpperCase();
                    }
					if($(this).attr('check') != '')
					{
						
						if($(this).attr('check')=="1")
						{
							
							
							if($(this).attr('value')==null)
							{
								
								$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
							}else
							{
								
								var thisReg = new RegExp($(this).attr('reg'));
								if(thisReg.test(this.value))
								{
									$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
								}
								else
								{
									$(this).removeClass('tooltipinputok').addClass('tooltipinputerr');
								}
								
							}
						}
						if($(this).attr('check')=="2")
						{
							var thisReg = new RegExp($(this).attr('reg'));
								if(thisReg.test(this.value))
								{
									$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
								}
								else
								{
									$(this).removeClass('tooltipinputok').addClass('tooltipinputerr');
								}
						}			
					}
                    
                });
            }
        });
        if(opts.onsubmit)
        {
            $('form').submit( function () {
                var isSubmit = true;
                getthis.each(function(){
					if($(this).attr('check')=="1")
						{
							
							
							if($(this).attr('value')==null)
							{
								
								$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
							}else
							{
								
								var thisReg = new RegExp($(this).attr('reg'));
								if(thisReg.test(this.value))
								{
									$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
								}
								else
								{
									$(this).removeClass('tooltipinputok').addClass('tooltipinputerr');
								}
								
							}
							isSubmit = false;
						}
                    if($(this).attr('check')=="2")
						{
							var thisReg = new RegExp($(this).attr('reg'));
								if(thisReg.test(this.value))
								{
									$(this).removeClass('tooltipinputerr').addClass('tooltipinputok');
								}
								else
								{
									$(this).removeClass('tooltipinputok').addClass('tooltipinputerr');
									isSubmit = false;
								}
						}			
                });
                return isSubmit;
            } );
        }
    };

    $.extend({
        getWidth : function(object) {
            return object.offsetWidth;
        },

        getLeft : function(object) {
            var go = object;
            var oParent,oLeft = go.offsetLeft;
            while(go.offsetParent!=null) {
                oParent = go.offsetParent;
                oLeft += oParent.offsetLeft;
                go = oParent;
            }
            return oLeft;
        },

        getTop : function(object) {
            var go = object;
            var oParent,oTop = go.offsetTop;
            while(go.offsetParent!=null) {
                oParent = go.offsetParent;
                oTop += oParent.offsetTop;
                go = oParent;
            }
            return oTop + $(object).height()+ 5;
        },

        onsubmit : true
    });
    $.fn.tooltip.defaults = { onsubmit: true };
})(jQuery);

//***************************************************************************************************************************************************
//����JQuery���ܶԱ�ǩ�������ñ��ʽ
//����ı�ǩID�����Ϊ"name1:name2:name3"�м���':'�ָ�.
//��������Ҫ������֤�ı�ǩ��������������ʽ
function setIntegeCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^[1-9]\\d*$");
		}
	}
}

//��������Ҫ�����֤�ı�ǩ��������������ʽ
function setMoneyCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^(-)?(([1-9]{1}\\d*)|([0]{1}))(\\.(\\d){1,2})?$");
		}
	}
}

//��������Ҫ��������֤�ı�ǩ��������������ʽ
function setFloatCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^[0-9]+\\.[0-9]+$");
		}
	}
}

//��������Ҫ�����ʼ���֤�ı�ǩ��������������ʽ
function setMailCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$");
		}
	}
}

//��������Ҫ�ʱ���֤�ı�ǩ��������������ʽ
function setZipcodeCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^\\d{6}$");
		}
	}
}

//��������Ҫ�ֻ���֤�ı�ǩ��������������ʽ
function setMobileCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^(13|15|18)[0-9]{9}$");
		}
	}
}

//��������Ҫ���֤��֤�ı�ǩ��������������ʽ
function setIDCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^[1-9]([0-9]{14}|[0-9]{17})$");
		}
	}
}

//��������Ҫ��¼�ʺ���֤�ı�ǩ��������������ʽ
function setUserIDCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^\\w+$");
		}
	}
}

//��������Ҫ�ǿ���֤�ı�ǩ��������������ʽ
function setEmptyCheck(validatorString)
{
	
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg",'.*\\S.*');
		}
	}
}

//��������Ҫ������֤�ı�ǩ��������������ʽ
function setChineseCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$");
		}
	}
}

//��������ҪURL��֤�ı�ǩ��������������ʽ
function setURLCheck(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$");
		}
	}
}
//ƥ����ڵ绰����(0511-4405222 �� 021-87888822) 
function setTell(validatorString)
{
	var validatorStrings="";
	if(validatorString!="")
	{
		validatorStrings=validatorString.split(":");
		for(i=0;i<validatorStrings.length;i++)
		{
			$("#"+validatorStrings[i]).attr("reg","\\d{3}-\\d{8}|\\d{4}-\\d{7}");
		}
	}
}  
//***************************************************************************************************************************************************