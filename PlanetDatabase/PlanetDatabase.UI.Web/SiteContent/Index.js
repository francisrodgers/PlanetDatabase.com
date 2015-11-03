$(function ()
{
    $(".Planets").on("click", function ()
    {
        ElementClicked = $(this).attr("id");
        PlanetName = $("#" + ElementClicked).children(".PlanetName").text().trim();

        $.ajax(
        {
            type: "GET",
            url: "http://localhost:56658/api/Planets/" + PlanetName,
            datatype: "json",
            cache: false,
        })
        .success(function (data)
        {
            if (data != null)
            {
                $("#" + ElementClicked).children(".Distance").text(LongNumberFormat(data.DistanceFromSun) + " km from Sun");
                $(".Planets").children(".Distance").hide();
                $("#" + ElementClicked).children(".Distance").show();
            }
        })

        return false;
    });

    $(document).ajaxStart(function ()
    {
        $("#loading").show();
    });

    $(document).ajaxStop(function ()
    {
        $("#loading").hide();
    });

    function LongNumberFormat(str)
    {
        str += '';
        x = str.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
        {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }
});
