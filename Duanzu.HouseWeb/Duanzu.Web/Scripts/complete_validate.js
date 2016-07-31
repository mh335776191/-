
// 输入字符的最大长度
function bytelength(str) {
    var len = 0;
    for (var i = 0; i < str.length; i++) {
        var c = str.charCodeAt(i);
        if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
            len++;
        }
        else {
            len += 2;
        }
    }
    return len;
}

//根据推荐人手机号码验证是否存在该用户
jQuery.validator.addMethod("CheckUserByMobile", function (value, element, params) {
    var prefix = params[0];
    var url = params[1];
    var result = false;
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        async: false,
        data: {
            TuiJianMobile: function () { return $("#" + prefix + "tuijianPerson").val(); }
        },
        success: function (response) {
            $("#" + prefix + "tuijianPerson").parent().find("abbr").remove();
            if (response.result) {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return this.optional(element) || result;
}, "<abbr class='message'>请输入正确的手机号码。</abbr>");

//验证推荐人手机号码是否与当前登录用户手机号码相同
jQuery.validator.addMethod("VaildEqual", function (value, element, params) {
    var prefix = params[0];
    var url = params[1];
    var loginmobile = params[2];
    var result = false;
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        async: false,
        data: {
            TuiJianMobile: function () { return $("#" + prefix + "tuijianPerson").val(); },
            loginmobile: function () { return loginmobile; }
        },
        success: function (response) {
            $("#" + prefix + "tuijianPerson").parent().find("abbr").remove();
            if (response.result) {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return this.optional(element) || result;
}, "<abbr class='message'>请重新输入。</abbr>");

// 验证小区是否可用
jQuery.validator.addMethod("IsVaildVillage", function (value, element, params) {
    var prefix = params[0];
    var url = params[1];
    var result = false;
    //if (bVaildVillage) { return true; }
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        async: false,
        data: {
            CityId: function () { return $("#" + prefix + "CityID").val(); },
            propType: function () { return $("#" + prefix + "PropertyType").val(); },
            VName: function () { return $("#" + prefix + "VillageName").val(); }
        },
        success: function (response) {
            $("#" + prefix + "VillageName").parent().find("abbr").remove();
            if (response.result) {
                result = true;
            } else {
                $("#" + prefix + "DistrictID").val("");
                $("#" + prefix + "DistrictName").val("");
                $("#" + prefix + "BusinessID").val("");
                $("#" + prefix + "BusinessName").val("");
                $("#" + prefix + "VillageID").val("");
                $("#" + prefix + "Address").val("");
                $("#" + prefix + "Lng").val("");
                $("#" + prefix + "Lat").val("");

            }
        }
    });
    return this.optional(element) || result;
}, "<abbr class='message'>请选择一项。</abbr>");

// 手机号码验证
jQuery.validator.addMethod("isMobile", function (value, element) {
    var length = value.length;

    return this.optional(element) || (length == 11 && /^1[34578][0-9]{1}\d{8}$/.test(value));
}, "<abbr class='message'>请输入正确的手机号码</abbr>");
// 楼层验证
jQuery.validator.addMethod("IsFloarCompare", function (value, element, params) {
    var thefloar = "0";
    var prefix = params[0];
    if ($("#" + prefix + "TheFloar").val() != undefined && $("#" + prefix + "TheFloar").length > 0) {
        thefloar = $("#" + prefix + "TheFloar").val();
    }
    return parseInt(thefloar) <= value ? true : false;
}, "<abbr class='message'>最高层必须大于或者等于所在楼层。</abbr>");
//验证长度
jQuery.validator.addMethod("rangeBLen", function (value, element, params) {
    var len = bytelength(value);
    return this.optional(element) || (params[0] <= len && len <= params[1]);
}, "<abbr class='message'>格式不正确!</abbr>");
//验证数字
jQuery.validator.addMethod("IsNumber", function (value, element) {
    return this.optional(element) || (/(^-?[1-9]\d*$)/.test(value));
}, "<abbr class='message'>限整数。</abbr>");
// 验证下拉框
jQuery.validator.addMethod("IsVaildSelected", function (value, element) {
    return value == 0 ? false : true;
}, "请选择一项。");
// 验证入住时间
jQuery.validator.addMethod("IsVaildDate", function (value, element) {

    var result = this.optional(element) || (/^\d{4}-[01]\d-[0-3]\d{1}$/.test(value));
    return result;

}, "格式不正确!");
// 验证楼层
// 验证入住时间
jQuery.validator.addMethod("VailTheFloor", function (value, element, params) {

    if (value != undefined) {
        var theFloor = parseInt(value);
        if ($("#" + params[0] + "AllFloor").val().length > 0) {
            var allFloor = parseInt($("#" + params[0] + "AllFloor").val());
            return theFloor <= allFloor;
        }
        else {
            // 没有总层数不进行验证
            return true;
        }
    }

    return true;

}, "<abbr class='message1'>所在楼层必须小于最高楼层</abbr>");

var form_validate = {
    form_vali: function () {
        $("#ShortRentForm").validate({
            onfocusout: false,
            focusInvalid: true,
            onkeyup: false,
            rules: {
                Room: {
                    required: true,
                    range: [1, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Hall: {
                    range: [0, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Toilet: {
                    range: [0, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Kitchen: {
                    range: [0, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Balcony: {
                    range: [0, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Bed: {
                    range: [0, 9],
                    rangelength: [1, 1],
                    digits: true
                },
                Area: {
                    required: true,
                    range: [0.1, 999999],
                    rangelength: [1, 6]
                },
                RentPrice: {
                    required: true,
                    range: [1, 1000000],
                    rangelength: [1, 6],
                    digits: true
                },
                Title: {
                    required: true,
                    rangeBLen: [6, 60]
                },
                Description: {
                    required: true
                },
                UserName: {
                    required: true,
                    rangeBLen: [1, 12]
                },
                Mobile: {
                    required: true,
                    isMobile: true
                }

            },
            messages: {
                Room: {
                    required: "<span class='er_noo ml15'>请填写房源户型</span>",
                    range: "<span class='er_noo ml15'>限数字1-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字1-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Hall: {
                    range: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Toilet: {
                    range: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Kitchen: {
                    range: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Balcony: {
                    range: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Bed: {
                    range: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    rangelength: "<span class='er_noo ml15'>限数字0-9，最高9，不支持小数点</span>",
                    digits: "<span class='er_noo ml15'>户型必须为数字，居室不能填写0</span>"
                },
                Area: {
                    required: "<abbr class='message'>出租面积不能为空</abbr>",
                    range: "<abbr class='message'>限1-6位数字,最高999999，不能为0</abbr>",
                    rangelength: "<abbr class='message'>限1-6位数字</abbr>"
                },
                RentPrice: {
                    required: "<abbr class='message'>租金不能为空</abbr>",
                    range: "<abbr class='message'>限1-6位数字，最高999999元</abbr>"
                    //                    rangelength: "<abbr class='message'>限1-6位数字，最高999999元，不支持小数点</abbr>",
                    //                    digits: "<abbr class='message'>限1-6位数字，最高999999元，不支持小数点</abbr>"
                },
                Title: {
                    required: "<abbr class='message'>标题不能为空</abbr>",
                    rangeBLen: "<abbr class='message'>限6-60个字符内，1个汉字等于2个字符</abbr>"
                },
                Description: {
                    required: "<abbr class='message1' style='margin-top:15px !important;'>房源描述不能为空</abbr>"

                },
                UserName: {
                    required: "<abbr class='message'>联系人不能为空</abbr>",
                    rangeBLen: "<abbr class='message'>不能超过6个汉字</abbr>"
                },
                Mobile: {
                    required: "<abbr class='message'>手机号码不能为空</abbr>",
                    isMobile: "<abbr class='message'>请输入正确的手机号码</abbr>"
                }
            },

            success: function (element) {
                element.parent().find("abbr").remove();

            },
            submitHandler: function (form) {
                var parm = $(form).serialize();
                var url = $(form).attr("action");

                //form_validate.loading();
                $.post(url, parm, function (response) {
                    if (response.result) {
                        window.location.href = response.UrlLink;
                    } else {
                        $(".l-window-mask").hide();
                        $("div[freeuiid='Dialog1001']").hide();
                        alert(response.message);
                    }

                });
            },
            onkeyup: false,
            errorElement: "abbr",
            ignore: "",
            errorPlacement: function (error, element) {
                element.parent().find("abbr").remove();
                //                error.appendTo(element.parent());
                //if (element.attr("lang") == "fn") {
                //    error.appendTo($("#" + prefix + "p_fn"));
                //} else {
                //    if (element.attr("lang") != "xq" || $.trim($("#" + prefix + "VillageName").val()) == "") {
                //        error.appendTo(element.parent());
                //    }
                //}
                if (element.is(':radio') || element.is(':checkbox')) {
                    error.appendTo(element.parent().parent().parent());
                } else {
                    error.appendTo(element.parent());
                }
            }

        });
    },
    loading: function () {
        $.freeDialog.open({ title: '', content: '<div class="loading"></div><div class="tac loadtxt">数据提交中…</div>', height: 220, width: 300, allowClose: true, showHeader: false, isHidden: false });
    }
}