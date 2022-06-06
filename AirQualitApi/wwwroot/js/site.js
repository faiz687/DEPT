// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#allCountriesList').select2({
        placeholder: "Select Countries here",
        allowClear: true
    });

    $('#allCitiesList').select2();

    $('#allCountriesList').on('change.select2', function (e) {

        var selectedCountries = $('#allCountriesList').select2('data');

        var selectedCountriesIds = selectedCountries.map(country => country.id)

        $.ajax({
            url: '/AirQuality/GetAllCities',
            data: { selectedCountries: selectedCountriesIds.toString() },
            type: "GET",
            cache: false,
            success: function (data) {
                // Transforms the top-level key of the response object from 'items' to 'results'
                console.log(data)


                $('#allCitiesList').select2({ data });



            }
        });



    });





});



