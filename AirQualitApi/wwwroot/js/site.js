// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('.AllCountriesList').select2({
        placeholder: "Select Countries here",
        allowClear: true
    });

    $('.AllCountriesList').on('change.select2', function (e) {

        var selectedCountries = $('.AllCountriesList').select2('data');

        var selectedCountriesIds = selectedCountries.map(country => country.id)

        $.ajax({
            url: '/AirQuality/GetAllCities',
            data: { countriesSelected: JSON.stringify(selectedCountriesIds) },
            type: "GET",
            cache: false,
            success: function (result) {
               
                
            }
        });

    });


});



