﻿
    // Đầu tiên chúng ta sẽ cần 3 biến
    // total_page, cur_page và một câu truy vấn dữ liệu

    var total_page, cur_page, collectionid, collectionSize;
    total_page = 6 // Tổng trang
    cur_page = 1; // Trang hiện tại
    collectionid = '0'; // Lưu collection id, để khi buyer click bỏ hết filter thì mình sẽ dựa vào id này để quay trở về trang bắt đầu.
    collectionSize = 102;
    var pageLimit = 18;
    var timeOutFilter;
    var check_slided_price = false; // Biến này để check phần filter price ( Nếu dùng input checkbox thì ko cần biến này )
    var check_url_param = false; // Biến này để check link url có filter hay ko vd : /collections/all?price=0:500000&vendor=juno
    var query = '';

    var quantityProductLeft = collectionSize - (cur_page * pageLimit);
    var loadingText = '<i class="fa fa-spinner fa-spin"></i> Loading...';
    var productLeftText = ('Xem Thêm (còn ' + quantityProductLeft + ' sản phẩm)');
    var btnLoading = $('.btn-loading'), productsContainer = $('.product-list'), hideFilter = $('.not-filter'), imgResize = $('.image-resize');

    function getProductLeft() {
        var quantityProductLeft = collectionSize - (cur_page * pageLimit);
        var _text = ('Xem Thêm (còn ' + quantityProductLeft + ' sản phẩm)');
        return _text;
    }

    if (quantityProductLeft > 0) {
        btnLoading.html(getProductLeft());
    } else {
        btnLoading.hide();
    }

    if (collectionid == 0) {
        query = "/search?q=filter=((collectionid:product>" + collectionid + ')';
    } else {
        query = "/search?q=filter=((collectionid:product=" + collectionid + ')';
    }
    var genQuery = function () {
        url_param = ''; // Biến này dùng để lưu phần filter của buyer đưa lên url
        _query = query; // Biến này để lưu câu truy vấn dữ liệu
        price = '', vendor = '', size1 = '', size2 = '', size3 = '', color = '', type = '';
        url_price = 'price=', url_vendor = 'vendor=', url_color = 'color=', url_size1 = 'size=', url_size2 = 'size=', url_size3 = 'size=', url_type = 'type=';

        if (check_slided_price) {
        price = jQuery('.filter-price input[type=radio]:checked').val();
            url_price = url_price + jQuery('.filter-price input[type=radio]:checked').attr('data-price');
            url_param = url_param + url_price + '&';
            _query = _query + '&&' + price;
        } else {
        url_price = '';
        }

        if (jQuery('.filter-vendor input:checked').length > 0) {
        jQuery('.filter-vendor li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                vendor = vendor + jQuery(this).find('input').val() + '||';
                url_vendor = url_vendor + $(this).find('label').attr('data-filter') + ',';
            }
        });
            vendor = vendor + '####';
            vendor = '(' + vendor.split('||####')[0] + ')';
            url_vendor = url_vendor + '####';
            url_vendor = url_vendor.split(',####')[0];
            url_param = url_param + url_vendor + '&';
            _query = _query + '&&' + vendor;
        } else {
        url_vendor = '';
        }

        if (jQuery('.filter-type input:checked').length > 0) {
        jQuery('.filter-type li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                type = type + jQuery(this).find('input').val() + '||';
                url_type = url_type + $(this).find('label').attr('data-filter') + ',';
            }
        });
            type = type + '####';
            type = '(' + type.split('||####')[0] + ')';
            url_type = url_type + '####';
            url_type = url_type.split(',####')[0];
            url_param = url_param + url_type + '&';
            _query = _query + '&&' + type;
        } else {
        url_type = '';
        }

        if (jQuery('.filter-size1 input:checked').length > 0) {
        jQuery('.filter-size1 li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                size1 = size1 + jQuery(this).find('input').val() + '||';
                url_size1 = url_size1 + $(this).find('label').attr('data-filter') + ',';
            }
        });
            size1 = size1 + '####';
            size1 = '(' + size1.split('||####')[0] + ')';
            url_size1 = url_size1 + '####';
            url_size1 = url_size1.split(',####')[0];
            url_param = url_param + url_size1 + '&';
            _query = _query + '&&' + size1;
            console.log('a');
        } else {
        url_size1 = '';
        }

        if (jQuery('.filter-size2 input:checked').length > 0) {
        jQuery('.filter-size2 li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                size2 = size2 + jQuery(this).find('input').val() + '||';
                url_size2 = url_size2 + $(this).find('label').attr('data-filter') + ',';
            }
        });
            size2 = size2 + '####';
            size2 = '(' + size2.split('||####')[0] + ')';
            url_size2 = url_size2 + '####';
            url_size2 = url_size2.split(',####')[0];
            url_param = url_param + url_size2 + '&';
            _query = _query + '&&' + size2;
        } else {
        url_size2 = '';
        }

        if (jQuery('.filter-size3 input:checked').length > 0) {
        jQuery('.filter-size3 li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                size3 = size3 + jQuery(this).find('input').val() + '||';
                url_size3 = url_size3 + $(this).find('label').attr('data-filter') + ',';
            }
        });
            size3 = size3 + '####';
            size3 = '(' + size3.split('||####')[0] + ')';
            url_size3 = url_size3 + '####';
            url_size3 = url_size3.split(',####')[0];
            url_param = url_param + url_size3 + '&';
            _query = _query + '&&' + size3;
        } else {
        url_size3 = '';
        }

        if (jQuery('.filter-color input:checked').length > 0) {
        jQuery('.filter-color li').each(function () {
            if (jQuery(this).find('input').is(':checked')) {
                color = color + jQuery(this).find('input').val() + '||';
                url_color = url_color + $(this).find('label').attr('data-filter') + ',';
            }
        });
            color = color + '####';
            color = '(' + color.split('||####')[0] + ')';
            url_color = url_color + '####';
            url_color = url_color.split(',####')[0];
            url_param = url_param + url_color + '&';
            _query = _query + '&&' + color;
        } else {
        url_color = '';
        }

        var query_final = _query + ')';
        if (check_slided_price == false && jQuery('.filter-type input:checked').length == 0 && jQuery('.filter-vendor input:checked').length == 0 && jQuery('.filter-variant input:checked').length == 0) {
            if (collectionid == 0) {
        query_final = "/search?q=filter=(collectionid:product>" + collectionid + ")";
            } else {
        query_final = "/search?q=filter=(collectionid:product=" + collectionid + ")";
            }
            if (check_url_param) {
        history.pushState(null, null, window.location.pathname);
            }
        } else {
        url_param = url_param + '####';
            url_param = url_param.split('&####')[0];
            if (check_url_param) {
        history.pushState(null, null, '?' + url_param);
            }
            if (cur_page >= 1 && check_url_param) {
        history.pushState(null, null, '?' + url_param);
            }
        }
        query_final = query_final.replace('/search?q=filter=', '');
        query_final = encodeURIComponent(query_final);
        query_final = '/search?q=filter=' + query_final;
        return query_final;
    }

    // Ở đây chúng ta sẽ setTimeout cho function này vì khi khách sản click liên tục sẽ dẫn đến
    // trạng request nhiều lần, nên mình sẽ setTimeout 1s để khi khách hàng click liên tục
    // sẽ không bị request nhiều lần nữa.
    var filter_append_product = function () {
        clearTimeout(timeOutFilter);
        timeOutFilter = setTimeout(function () {
        total_page = 0, cur_page = 1;
            url = genQuery();
            jQuery.ajax({
        url: url + '&view=pagesize',
                success: function (data) {
        total_page = parseInt(data.split('####')[0]);
                    collectionSize = parseInt(data.split('####')[1]);
                    console.log('collection-size=' + collectionSize);
                    btnLoading.hide();
                    if (total_page > 1) {
        btnLoading.html(getProductLeft());
                        btnLoading.show();
                    }
                }
            });
            //lay trang dau tien
            jQuery.ajax({
        url: url + '&view=filter',
                success: function (data) {
        loadingcomplete = true;
                    //$('.empty').remove(); // Xóa phần thông báo hết hàng or không tìm thấy khi filter -> đặt class empty vào đoạn html đó
                    productsContainer.html(''); // Xóa dữ liệu củ
                    hideFilter.remove();
                    productsContainer.append(data);
                }
            });
        }, 1000);
    }

    var filter_append_product_by_page = function (queryByPage) {
        jQuery.ajax({
            url: queryByPage,
            success: function (data) {
                loadingcomplete = true;
                productsContainer.html(data);
                hideFilter.remove();
            }
        });
    }

    // Khi buyer click vào input mình sẽ bắt sự kiện change của nó và chạy function filter_append_product() để get dữ liệu.
    jQuery(document).ready(function () {
        jQuery('.filter-vendor input').change(function () {
            filter_append_product();
        });
        jQuery('.filter-type input').change(function () {
        filter_append_product();
        });
        jQuery('.filter-size1 input').change(function () {
        filter_append_product();
        });
        jQuery('.filter-size2 input').change(function () {
        filter_append_product();
        });
        jQuery('.filter-size3 input').change(function () {
        filter_append_product();
        });
        jQuery('.filter-color input').change(function () {
        filter_append_product();
        });
        jQuery('.filter-price input').change(function () {
        check_slided_price = true;
            filter_append_product();
        });

        // Phần điều kiện này dùng để lấy dữ liệu filter từ url nếu có vd : /collections/all?price=0:500000&vendor=juno
        if (window.location.search != '' && window.location.search.indexOf('?page=') != 0) {
        $('.filter-vendor input:checkbox,.filter-type input:checkbox,.filter-variant input:checkbox,.filter-price input:radio').prop('checked', false);// Unclock checked input filter
            filter_value = [];
            link_url = window.location.search.replace('?', '').split('&');
            if (link_url.length > 0) {
        $.each(link_url, function (i, v) {
            filter_value[v.split('=')[0]] = v.split('=')[1];
        });
            }
            if (filter_value["price"] != undefined) {
                if (jQuery(".filter-price input[data-price='" + filter_value["price"] + "']").length > 0) {
        jQuery(".filter-price input[data-price='" + filter_value["price"] + "']").click();
                }
            }
            if (filter_value["vendor"] != undefined) {
        $.each(filter_value["vendor"].split(','), function (i, v) {
            $('.filter-vendor .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            if (filter_value["type"] != undefined) {
        $.each(filter_value["type"].split(','), function (i, v) {
            $('.filter-type .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            if (filter_value["color"] != undefined) {
        $.each(filter_value["color"].split(','), function (i, v) {
            $('.filter-color .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            if (filter_value["size1"] != undefined) {
        $.each(filter_value["size1"].split(','), function (i, v) {
            $('.filter-size1 .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            if (filter_value["size2"] != undefined) {
        $.each(filter_value["size2"].split(','), function (i, v) {
            $('.filter-size2 .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            if (filter_value["size3"] != undefined) {
        $.each(filter_value["size3"].split(','), function (i, v) {
            $('.filter-size3 .' + convertToSlug(decodeURIComponent(v)) + ' input').click();
        });
            }
            check_url_param = true;
        } else {
        check_url_param = true;
        }
    });

    var loadingcomplete = true, isloading = false;


    // Xữ lý nút load more
    jQuery(document).on("click", '.btn-loading', function () {
        loadingcomplete = false;
        if (!isloading && cur_page < total_page) {
        isloading = true;
            cur_page++;
            btnLoading.html(loadingText);
            $.ajax({
        url: genQuery() + '&view=filter&page=' + cur_page,
                success: function (data) {
        pos_scrollTop = jQuery(window).scrollTop();
                    jQuery('.empty').remove();
                    productsContainer.append(data);
                    jQuery(window).scrollTop(pos_scrollTop);
                    isloading = false;
                    loadingcomplete = true;
                    if (cur_page == total_page) {
        btnLoading.hide();
                    } else {
        btnLoading.html(getProductLeft());
                    }
                }
            });
        }
    });