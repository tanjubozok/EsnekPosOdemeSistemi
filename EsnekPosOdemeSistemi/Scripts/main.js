
$(document).on("click", "#buttonPost", function () {
    var CardOwner = $('#CardOwner').val();
    var CardNumber = $('#CardNumber').val();
    var CardExpireMonth = $('#CardExpireMonth').val();
    var CardExpireYear = $('#CardExpireYear').val();
    var CardSecurityCode = $('#CardSecurityCode').val();
    var Amount = $('#Amount').val();

    var creditCard = {
        CC_OWNER: CardOwner,
        CC_NUMBER: CardNumber,
        EXP_MONTH: CardExpireMonth,
        EXP_YEAR: CardExpireYear,
        CC_CVV: CardSecurityCode,
        ORDER_AMOUNT: Amount
    };

    $('#buttonPost').html('Kontrol Ediliyor...');
    $('#buttonPost').prop('disabled', true);

    if (CardOwner != "" && CardNumber != "" && CardExpireMonth != "" && CardExpireYear != "" && CardSecurityCode != "" && Amount != "") {
        $.ajax({
            url: "/Payment/CreditCard",
            type: "POST",
            data: { creditCard: creditCard },
            success: function (response) {
                if (response.Result == "1") {
                    Swal.fire("Dikkat!", "Sms Ekranına Yönleniyorsunuz..", "warning");
                    setTimeout(function () {
                        window.location.href = response.Url;
                    }, 3000);
                } else {
                    Swal.fire("HATA!", "Hata oluştu.", "error");
                }
            },
            complete: function () {
                $('#buttonPost').html('İşlemi Başlat');
                $('#buttonPost').prop('disabled', false);
            }
        });
    }
    else {
        Swal.fire("HATA!", "Bütün alanları eksiksiz doldurduğunuzdan emin olun!", "error");
        $('#buttonPost').html('İşlemi Başlat');
        $('#buttonPost').prop('disabled', false);
    }
});