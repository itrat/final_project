

var Getdecoration= function () {
            var selectedrestaurantval = $("#restaurant").val();
            $.ajax({
                type: 'Post',
                url: "/Reservation/GetCoursebydept",
                contentType: "application/json; charset=utf-8",
                datatype:"json",
                data: JSON.stringify({ "did": selectedrestaurantval }),
                success: function (msg)
                {
                    //alert('success');
                    //alert(msg);
                    //$("#signin").html(msg);
                    var ddhtml = "";
                    $.each(msg, function (key,value)
                    {
                        if(key==0)
                            ddhtml = ddhtml + '<option value="' + value[0].Decoration_Id + '">' + value[0].Decoration_Type + '</options>'
                        
                    });
                    $('#event').html(ddhtml)
                    $.each(msg, function (key, value) {
                        if(key==0)
                        ddhtml = ddhtml + '<option value="' + value[0].Decoration_Id + '">' + value[0].Decoration_Type + '</options>'

                    });
                    $('#dec').html(ddhtml) 
                    $.each(msg, function (key,value)
                    {
                        if(key==1)
                        ddhtml = ddhtml + '<option value="' + value[0].Food_Id + '">' + value[0].Food_Item + '</options>'
                        
                    });
                    $('#food').html(ddhtml)
                    $.each(msg, function (key, value)
                    {
                        if(key==4)
                        ddhtml = ddhtml + '<option value="' + value[0].Sound_Id + '">' + value[0].Sound_Type + '</options>'
                        
                    });
                    $('#sound').html(ddhtml)
                },
                fail: function (jqXHR,textStatus,errorThrown)
                {
                    alert("fail" + error.message+ errorThrown+ textStatus+ errorThrown.message);
                }
                
            });


        }
                


