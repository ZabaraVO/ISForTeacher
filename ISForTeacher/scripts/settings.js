$('#settings').on("click", function () {
    var settingsItems=$('#settingsItems');
    var display = settingsItems.css('display');
    var newDisplay='none';
    if (display == 'none')
        newDisplay = 'block';
    settingsItems.css('display',newDisplay);
});