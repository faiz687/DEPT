// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#SelectedCountries').select2({
        placeholder: "Click to select countries"
    });

    $('#SelectedCities').select2({
        placeholder: "Click to select cities",
        language: {
            "noResults": function () {
                return "Select a country";
            }
        }
    });

    $('#SelectedCountries').on('change.select2', function (e) {

        $('#SelectedCities').empty();

        var selectedCountries = $('#SelectedCountries').select2('data');
      
        if (selectedCountries.length > 0) {

            var selectedCountriesIds = selectedCountries.map(country => country.id)
           
            $.ajax({
                url: '/AirQuality/GetAllCities',
                data: { selectedCountries: selectedCountriesIds.toString() },
                type: "GET",
                cache: false,
                success: function (data) {
                    if (data) {                                        
                        $('#SelectedCities').select2({
                            data,
                            placeholder: "Click to select cities",
                            language: {
                                "noResults": function () {
                                    return "Select a country";
                                }
                            }
                        });
                    }
                }
            });
        }
    });








});



