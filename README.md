# Json-API-Manipulation
Semester Project Sunrise Sunset

The project will require the addition of new references
1)	Newtonsoft.Json
2)	Microsoft.AspNet.WebApi.Client

The project will require the following classes:
1)	APIHelper
a.	Contains the Set Up for the ApiClilent
b.	The DefaultRequestHeaders setup

2)	SunModel
a.	Defines the object that holds the following datetime fields
i.	Sunrise
ii.	Sunset
iii.	Solar_noon
iv.	Day_length
v.	Civil_twilight_begin
vi.	Civil_twilight_end
vii.	Nautical_twilight_begin
viii.	Nautical_twilight_end
ix.	Astronomical_twilight_begin
x.	Astronomical_twilight_end
3)	SunResultModel
a.	Holds the Results variable with the SunModel data type
4)	SunProcessor
a.	Holds the logic needed to download the data from the url: “https://api.sunrise-sunset.org/json?lat=35.045631&lng=-85.309677.
b.	Note that since the program is referring to an outside source for data, the methods should be ‘async’.
5)	Form1
a.	Any methods that are dealing with the data acquisition need to be ‘async’.
b.	All times returned from the api need to be converted to local time. See the documentation for DateTime utility class.
