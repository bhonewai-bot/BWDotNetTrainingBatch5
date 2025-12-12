using BWDotNetTrainingBatch5.ChartWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BWDotNetTrainingBatch5.ChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartModel model = new ApexChartPieChartModel();
            model.Series = new int[] { 44, 55, 13, 43, 22 };
            model.Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };
            return View(model);
        }
        
        public IActionResult MixedChart()
        {
            ApexChartMixedChartModel model = new ApexChartMixedChartModel();
    
            model.Series = new List<SeriesData>
            {
                new SeriesData
                {
                    Name = "TEAM A",
                    Type = "column",
                    Data = new int[] { 23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30 }
                },
                new SeriesData
                {
                    Name = "TEAM B",
                    Type = "area",
                    Data = new int[] { 44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43 }
                },
                new SeriesData
                {
                    Name = "TEAM C",
                    Type = "line",
                    Data = new int[] { 30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39 }
                }
            };
    
            model.Labels = new string[] 
            { 
                "01/01/2003", "02/01/2003", "03/01/2003", "04/01/2003", 
                "05/01/2003", "06/01/2003", "07/01/2003", "08/01/2003", 
                "09/01/2003", "10/01/2003", "11/01/2003"
            };
    
            return View(model);
        }
        
        public IActionResult CandlestickChart()
        {
            ApexChartCandlestickModel model = new ApexChartCandlestickModel();
            
            model.LineData = new List<LineSeriesData>
            {
                new LineSeriesData { X = 1538778600000, Y = 6604 },
                new LineSeriesData { X = 1538782200000, Y = 6602 },
                new LineSeriesData { X = 1538814600000, Y = 6607 },
                new LineSeriesData { X = 1538884800000, Y = 6620 }
            };
            
            model.CandlestickData = new List<CandlestickSeriesData>
            {
                new CandlestickSeriesData { X = 1538778600000, Y = new decimal[] { 6629.81m, 6650.5m, 6623.04m, 6633.33m } },
                new CandlestickSeriesData { X = 1538780400000, Y = new decimal[] { 6632.01m, 6643.59m, 6620m, 6630.11m } },
                new CandlestickSeriesData { X = 1538782200000, Y = new decimal[] { 6630.71m, 6648.95m, 6623.34m, 6635.65m } },
                new CandlestickSeriesData { X = 1538784000000, Y = new decimal[] { 6635.65m, 6651m, 6629.67m, 6638.24m } },
                new CandlestickSeriesData { X = 1538785800000, Y = new decimal[] { 6638.24m, 6640m, 6620m, 6624.47m } },
                new CandlestickSeriesData { X = 1538787600000, Y = new decimal[] { 6624.53m, 6636.03m, 6621.68m, 6624.31m } },
                new CandlestickSeriesData { X = 1538789400000, Y = new decimal[] { 6624.61m, 6632.2m, 6617m, 6626.02m } },
                new CandlestickSeriesData { X = 1538791200000, Y = new decimal[] { 6627m, 6627.62m, 6584.22m, 6603.02m } },
                new CandlestickSeriesData { X = 1538793000000, Y = new decimal[] { 6605m, 6608.03m, 6598.95m, 6604.01m } },
                new CandlestickSeriesData { X = 1538794800000, Y = new decimal[] { 6604.5m, 6614.4m, 6602.26m, 6608.02m } },
                new CandlestickSeriesData { X = 1538796600000, Y = new decimal[] { 6608.02m, 6610.68m, 6601.99m, 6608.91m } },
                new CandlestickSeriesData { X = 1538798400000, Y = new decimal[] { 6608.91m, 6618.99m, 6608.01m, 6612m } },
                new CandlestickSeriesData { X = 1538800200000, Y = new decimal[] { 6612m, 6615.13m, 6605.09m, 6612m } },
                new CandlestickSeriesData { X = 1538802000000, Y = new decimal[] { 6612m, 6624.12m, 6608.43m, 6622.95m } },
                new CandlestickSeriesData { X = 1538803800000, Y = new decimal[] { 6623.91m, 6623.91m, 6615m, 6615.67m } },
                new CandlestickSeriesData { X = 1538805600000, Y = new decimal[] { 6618.69m, 6618.74m, 6610m, 6610.4m } },
                new CandlestickSeriesData { X = 1538807400000, Y = new decimal[] { 6611m, 6622.78m, 6610.4m, 6614.9m } },
                new CandlestickSeriesData { X = 1538809200000, Y = new decimal[] { 6614.9m, 6626.2m, 6613.33m, 6623.45m } },
                new CandlestickSeriesData { X = 1538811000000, Y = new decimal[] { 6623.48m, 6627m, 6618.38m, 6620.35m } },
                new CandlestickSeriesData { X = 1538812800000, Y = new decimal[] { 6619.43m, 6620.35m, 6610.05m, 6615.53m } },
                new CandlestickSeriesData { X = 1538814600000, Y = new decimal[] { 6615.53m, 6617.93m, 6610m, 6615.19m } },
                new CandlestickSeriesData { X = 1538816400000, Y = new decimal[] { 6615.19m, 6621.6m, 6608.2m, 6620m } },
                new CandlestickSeriesData { X = 1538818200000, Y = new decimal[] { 6619.54m, 6625.17m, 6614.15m, 6620m } },
                new CandlestickSeriesData { X = 1538820000000, Y = new decimal[] { 6620.33m, 6634.15m, 6617.24m, 6624.61m } },
                new CandlestickSeriesData { X = 1538821800000, Y = new decimal[] { 6625.95m, 6626m, 6611.66m, 6617.58m } },
                new CandlestickSeriesData { X = 1538823600000, Y = new decimal[] { 6619m, 6625.97m, 6595.27m, 6598.86m } },
                new CandlestickSeriesData { X = 1538825400000, Y = new decimal[] { 6598.86m, 6598.88m, 6570m, 6587.16m } },
                new CandlestickSeriesData { X = 1538827200000, Y = new decimal[] { 6588.86m, 6600m, 6580m, 6593.4m } },
                new CandlestickSeriesData { X = 1538829000000, Y = new decimal[] { 6593.99m, 6598.89m, 6585m, 6587.81m } },
                new CandlestickSeriesData { X = 1538830800000, Y = new decimal[] { 6587.81m, 6592.73m, 6567.14m, 6578m } },
                new CandlestickSeriesData { X = 1538832600000, Y = new decimal[] { 6578.35m, 6581.72m, 6567.39m, 6579m } },
                new CandlestickSeriesData { X = 1538834400000, Y = new decimal[] { 6579.38m, 6580.92m, 6566.77m, 6575.96m } },
                new CandlestickSeriesData { X = 1538836200000, Y = new decimal[] { 6575.96m, 6589m, 6571.77m, 6588.92m } },
                new CandlestickSeriesData { X = 1538838000000, Y = new decimal[] { 6588.92m, 6594m, 6577.55m, 6589.22m } },
                new CandlestickSeriesData { X = 1538839800000, Y = new decimal[] { 6589.3m, 6598.89m, 6589.1m, 6596.08m } },
                new CandlestickSeriesData { X = 1538841600000, Y = new decimal[] { 6597.5m, 6600m, 6588.39m, 6596.25m } },
                new CandlestickSeriesData { X = 1538843400000, Y = new decimal[] { 6598.03m, 6600m, 6588.73m, 6595.97m } },
                new CandlestickSeriesData { X = 1538845200000, Y = new decimal[] { 6595.97m, 6602.01m, 6588.17m, 6602m } },
                new CandlestickSeriesData { X = 1538847000000, Y = new decimal[] { 6602m, 6607m, 6596.51m, 6599.95m } },
                new CandlestickSeriesData { X = 1538848800000, Y = new decimal[] { 6600.63m, 6601.21m, 6590.39m, 6591.02m } },
                new CandlestickSeriesData { X = 1538850600000, Y = new decimal[] { 6591.02m, 6603.08m, 6591m, 6591m } },
                new CandlestickSeriesData { X = 1538852400000, Y = new decimal[] { 6591m, 6601.32m, 6585m, 6592m } },
                new CandlestickSeriesData { X = 1538854200000, Y = new decimal[] { 6593.13m, 6596.01m, 6590m, 6593.34m } },
                new CandlestickSeriesData { X = 1538856000000, Y = new decimal[] { 6593.34m, 6604.76m, 6582.63m, 6593.86m } },
                new CandlestickSeriesData { X = 1538857800000, Y = new decimal[] { 6593.86m, 6604.28m, 6586.57m, 6600.01m } },
                new CandlestickSeriesData { X = 1538859600000, Y = new decimal[] { 6601.81m, 6603.21m, 6592.78m, 6596.25m } },
                new CandlestickSeriesData { X = 1538861400000, Y = new decimal[] { 6596.25m, 6604.2m, 6590m, 6602.99m } },
                new CandlestickSeriesData { X = 1538863200000, Y = new decimal[] { 6602.99m, 6606m, 6584.99m, 6587.81m } },
                new CandlestickSeriesData { X = 1538865000000, Y = new decimal[] { 6587.81m, 6595m, 6583.27m, 6591.96m } },
                new CandlestickSeriesData { X = 1538866800000, Y = new decimal[] { 6591.97m, 6596.07m, 6585m, 6588.39m } },
                new CandlestickSeriesData { X = 1538868600000, Y = new decimal[] { 6587.6m, 6598.21m, 6587.6m, 6594.27m } },
                new CandlestickSeriesData { X = 1538870400000, Y = new decimal[] { 6596.44m, 6601m, 6590m, 6596.55m } },
                new CandlestickSeriesData { X = 1538872200000, Y = new decimal[] { 6598.91m, 6605m, 6596.61m, 6600.02m } },
                new CandlestickSeriesData { X = 1538874000000, Y = new decimal[] { 6600.55m, 6605m, 6589.14m, 6593.01m } },
                new CandlestickSeriesData { X = 1538875800000, Y = new decimal[] { 6593.15m, 6605m, 6592m, 6603.06m } },
                new CandlestickSeriesData { X = 1538877600000, Y = new decimal[] { 6603.07m, 6604.5m, 6599.09m, 6603.89m } },
                new CandlestickSeriesData { X = 1538879400000, Y = new decimal[] { 6604.44m, 6604.44m, 6600m, 6603.5m } },
                new CandlestickSeriesData { X = 1538881200000, Y = new decimal[] { 6603.5m, 6603.99m, 6597.5m, 6603.86m } },
                new CandlestickSeriesData { X = 1538883000000, Y = new decimal[] { 6603.85m, 6605m, 6600m, 6604.07m } },
                new CandlestickSeriesData { X = 1538884800000, Y = new decimal[] { 6604.98m, 6606m, 6604.07m, 6606m } }
            };
            
            return View(model);
        }
        
        public IActionResult ColumnChart()
        {
            ColumnChartModel model = new ColumnChartModel();
    
            model.Series = new List<ColumnSeriesData>
            {
                new ColumnSeriesData 
                { 
                    Name = "Net Profit", 
                    Data = new int[] { 44, 55, 57, 56, 61, 58, 63, 60, 66 } 
                },
                new ColumnSeriesData 
                { 
                    Name = "Revenue", 
                    Data = new int[] { 76, 85, 101, 98, 87, 105, 91, 114, 94 } 
                },
                new ColumnSeriesData 
                { 
                    Name = "Free Cash Flow", 
                    Data = new int[] { 35, 41, 36, 26, 45, 48, 52, 53, 41 } 
                }
            };
    
            model.Categories = new string[] { "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct" };
    
            return View(model);
        }
        
        public IActionResult AreaChart()
        {
            ApexChartAreaChartModel model = new ApexChartAreaChartModel();
            
            model.Data = new List<AreaChartData>
            {
                new AreaChartData { Timestamp = 1327359600000, Value = 30.95m },
                new AreaChartData { Timestamp = 1327446000000, Value = 31.34m },
                new AreaChartData { Timestamp = 1327532400000, Value = 31.18m },
                new AreaChartData { Timestamp = 1327618800000, Value = 31.05m },
                new AreaChartData { Timestamp = 1327878000000, Value = 31.00m },
                new AreaChartData { Timestamp = 1327964400000, Value = 30.95m },
                new AreaChartData { Timestamp = 1328050800000, Value = 31.24m },
                new AreaChartData { Timestamp = 1328137200000, Value = 31.29m },
                new AreaChartData { Timestamp = 1328223600000, Value = 31.85m },
                new AreaChartData { Timestamp = 1328482800000, Value = 31.86m },
                new AreaChartData { Timestamp = 1328569200000, Value = 32.28m },
                new AreaChartData { Timestamp = 1328655600000, Value = 32.10m },
                new AreaChartData { Timestamp = 1328742000000, Value = 32.65m },
                new AreaChartData { Timestamp = 1328828400000, Value = 32.21m },
                new AreaChartData { Timestamp = 1329087600000, Value = 32.35m },
                new AreaChartData { Timestamp = 1329174000000, Value = 32.44m },
                new AreaChartData { Timestamp = 1329260400000, Value = 32.46m },
                new AreaChartData { Timestamp = 1329346800000, Value = 32.86m },
                new AreaChartData { Timestamp = 1329433200000, Value = 32.75m },
                new AreaChartData { Timestamp = 1329778800000, Value = 32.54m },
                new AreaChartData { Timestamp = 1329865200000, Value = 32.33m },
                new AreaChartData { Timestamp = 1329951600000, Value = 32.97m },
                new AreaChartData { Timestamp = 1330038000000, Value = 33.41m },
                new AreaChartData { Timestamp = 1330297200000, Value = 33.27m },
                new AreaChartData { Timestamp = 1330383600000, Value = 33.27m },
                new AreaChartData { Timestamp = 1330470000000, Value = 32.89m },
                new AreaChartData { Timestamp = 1330556400000, Value = 33.10m },
                new AreaChartData { Timestamp = 1330642800000, Value = 33.73m },
                new AreaChartData { Timestamp = 1330902000000, Value = 33.22m },
                new AreaChartData { Timestamp = 1330988400000, Value = 31.99m },
                new AreaChartData { Timestamp = 1331074800000, Value = 32.41m },
                new AreaChartData { Timestamp = 1331161200000, Value = 33.05m },
                new AreaChartData { Timestamp = 1331247600000, Value = 33.64m },
                new AreaChartData { Timestamp = 1331506800000, Value = 33.56m },
                new AreaChartData { Timestamp = 1331593200000, Value = 34.22m },
                new AreaChartData { Timestamp = 1331679600000, Value = 33.77m },
                new AreaChartData { Timestamp = 1331766000000, Value = 34.17m },
                new AreaChartData { Timestamp = 1331852400000, Value = 33.82m },
                new AreaChartData { Timestamp = 1332111600000, Value = 34.51m },
                new AreaChartData { Timestamp = 1332198000000, Value = 33.16m },
                new AreaChartData { Timestamp = 1332284400000, Value = 33.56m },
                new AreaChartData { Timestamp = 1332370800000, Value = 33.71m },
                new AreaChartData { Timestamp = 1332457200000, Value = 33.81m },
                new AreaChartData { Timestamp = 1332712800000, Value = 34.40m },
                new AreaChartData { Timestamp = 1332799200000, Value = 34.63m },
                new AreaChartData { Timestamp = 1332885600000, Value = 34.46m },
                new AreaChartData { Timestamp = 1332972000000, Value = 34.48m },
                new AreaChartData { Timestamp = 1333058400000, Value = 34.31m },
                new AreaChartData { Timestamp = 1333317600000, Value = 34.70m },
                new AreaChartData { Timestamp = 1333404000000, Value = 34.31m },
                new AreaChartData { Timestamp = 1333490400000, Value = 33.46m },
                new AreaChartData { Timestamp = 1333576800000, Value = 33.59m },
                new AreaChartData { Timestamp = 1333922400000, Value = 33.22m },
                new AreaChartData { Timestamp = 1334008800000, Value = 32.61m },
                new AreaChartData { Timestamp = 1334095200000, Value = 33.01m },
                new AreaChartData { Timestamp = 1334181600000, Value = 33.55m },
                new AreaChartData { Timestamp = 1334268000000, Value = 33.18m },
                new AreaChartData { Timestamp = 1334527200000, Value = 32.84m },
                new AreaChartData { Timestamp = 1334613600000, Value = 33.84m },
                new AreaChartData { Timestamp = 1334700000000, Value = 33.39m },
                new AreaChartData { Timestamp = 1334786400000, Value = 32.91m },
                new AreaChartData { Timestamp = 1334872800000, Value = 33.06m },
                new AreaChartData { Timestamp = 1335132000000, Value = 32.62m },
                new AreaChartData { Timestamp = 1335218400000, Value = 32.40m },
                new AreaChartData { Timestamp = 1335304800000, Value = 33.13m },
                new AreaChartData { Timestamp = 1335391200000, Value = 33.26m },
                new AreaChartData { Timestamp = 1335477600000, Value = 33.58m },
                new AreaChartData { Timestamp = 1335736800000, Value = 33.55m },
                new AreaChartData { Timestamp = 1335823200000, Value = 33.77m },
                new AreaChartData { Timestamp = 1335909600000, Value = 33.76m },
                new AreaChartData { Timestamp = 1335996000000, Value = 33.32m },
                new AreaChartData { Timestamp = 1336082400000, Value = 32.61m },
                new AreaChartData { Timestamp = 1336341600000, Value = 32.52m },
                new AreaChartData { Timestamp = 1336428000000, Value = 32.67m },
                new AreaChartData { Timestamp = 1336514400000, Value = 32.52m },
                new AreaChartData { Timestamp = 1336600800000, Value = 31.92m },
                new AreaChartData { Timestamp = 1336687200000, Value = 32.20m },
                new AreaChartData { Timestamp = 1336946400000, Value = 32.23m },
                new AreaChartData { Timestamp = 1337032800000, Value = 32.33m },
                new AreaChartData { Timestamp = 1337119200000, Value = 32.36m },
                new AreaChartData { Timestamp = 1337205600000, Value = 32.01m },
                new AreaChartData { Timestamp = 1337292000000, Value = 31.31m },
                new AreaChartData { Timestamp = 1337551200000, Value = 32.01m },
                new AreaChartData { Timestamp = 1337637600000, Value = 32.01m },
                new AreaChartData { Timestamp = 1337724000000, Value = 32.18m },
                new AreaChartData { Timestamp = 1337810400000, Value = 31.54m },
                new AreaChartData { Timestamp = 1337896800000, Value = 31.60m },
                new AreaChartData { Timestamp = 1338242400000, Value = 32.05m },
                new AreaChartData { Timestamp = 1338328800000, Value = 31.29m },
                new AreaChartData { Timestamp = 1338415200000, Value = 31.05m },
                new AreaChartData { Timestamp = 1338501600000, Value = 29.82m },
                new AreaChartData { Timestamp = 1338760800000, Value = 30.31m },
                new AreaChartData { Timestamp = 1338847200000, Value = 30.70m },
                new AreaChartData { Timestamp = 1338933600000, Value = 31.69m },
                new AreaChartData { Timestamp = 1339020000000, Value = 31.32m },
                new AreaChartData { Timestamp = 1339106400000, Value = 31.65m },
                new AreaChartData { Timestamp = 1339365600000, Value = 31.13m },
                new AreaChartData { Timestamp = 1339452000000, Value = 31.77m },
                new AreaChartData { Timestamp = 1339538400000, Value = 31.79m },
                new AreaChartData { Timestamp = 1339624800000, Value = 31.67m },
                new AreaChartData { Timestamp = 1339711200000, Value = 32.39m },
                new AreaChartData { Timestamp = 1339970400000, Value = 32.63m },
                new AreaChartData { Timestamp = 1340056800000, Value = 32.89m },
                new AreaChartData { Timestamp = 1340143200000, Value = 31.99m },
                new AreaChartData { Timestamp = 1340229600000, Value = 31.23m },
                new AreaChartData { Timestamp = 1340316000000, Value = 31.57m },
                new AreaChartData { Timestamp = 1340575200000, Value = 30.84m },
                new AreaChartData { Timestamp = 1340661600000, Value = 31.07m },
                new AreaChartData { Timestamp = 1340748000000, Value = 31.41m },
                new AreaChartData { Timestamp = 1340834400000, Value = 31.17m },
                new AreaChartData { Timestamp = 1340920800000, Value = 32.37m },
                new AreaChartData { Timestamp = 1341180000000, Value = 32.19m },
                new AreaChartData { Timestamp = 1341266400000, Value = 32.51m },
                new AreaChartData { Timestamp = 1341439200000, Value = 32.53m },
                new AreaChartData { Timestamp = 1341525600000, Value = 31.37m },
                new AreaChartData { Timestamp = 1341784800000, Value = 30.43m },
                new AreaChartData { Timestamp = 1341871200000, Value = 30.44m },
                new AreaChartData { Timestamp = 1341957600000, Value = 30.20m },
                new AreaChartData { Timestamp = 1342044000000, Value = 30.14m },
                new AreaChartData { Timestamp = 1342130400000, Value = 30.65m },
                new AreaChartData { Timestamp = 1342389600000, Value = 30.40m },
                new AreaChartData { Timestamp = 1342476000000, Value = 30.65m },
                new AreaChartData { Timestamp = 1342562400000, Value = 31.43m },
                new AreaChartData { Timestamp = 1342648800000, Value = 31.89m },
                new AreaChartData { Timestamp = 1342735200000, Value = 31.38m },
                new AreaChartData { Timestamp = 1342994400000, Value = 30.64m },
                new AreaChartData { Timestamp = 1343080800000, Value = 30.02m },
                new AreaChartData { Timestamp = 1343167200000, Value = 30.33m },
                new AreaChartData { Timestamp = 1343253600000, Value = 30.95m },
                new AreaChartData { Timestamp = 1343340000000, Value = 31.89m },
                new AreaChartData { Timestamp = 1343599200000, Value = 31.01m },
                new AreaChartData { Timestamp = 1343685600000, Value = 30.88m },
                new AreaChartData { Timestamp = 1343772000000, Value = 30.69m },
                new AreaChartData { Timestamp = 1343858400000, Value = 30.58m },
                new AreaChartData { Timestamp = 1343944800000, Value = 32.02m },
                new AreaChartData { Timestamp = 1344204000000, Value = 32.14m },
                new AreaChartData { Timestamp = 1344290400000, Value = 32.37m },
                new AreaChartData { Timestamp = 1344376800000, Value = 32.51m },
                new AreaChartData { Timestamp = 1344463200000, Value = 32.65m },
                new AreaChartData { Timestamp = 1344549600000, Value = 32.64m },
                new AreaChartData { Timestamp = 1344808800000, Value = 32.27m },
                new AreaChartData { Timestamp = 1344895200000, Value = 32.10m },
                new AreaChartData { Timestamp = 1344981600000, Value = 32.91m },
                new AreaChartData { Timestamp = 1345068000000, Value = 33.65m },
                new AreaChartData { Timestamp = 1345154400000, Value = 33.80m },
                new AreaChartData { Timestamp = 1345413600000, Value = 33.92m },
                new AreaChartData { Timestamp = 1345500000000, Value = 33.75m },
                new AreaChartData { Timestamp = 1345586400000, Value = 33.84m },
                new AreaChartData { Timestamp = 1345672800000, Value = 33.50m },
                new AreaChartData { Timestamp = 1345759200000, Value = 32.26m },
                new AreaChartData { Timestamp = 1346018400000, Value = 32.32m },
                new AreaChartData { Timestamp = 1346104800000, Value = 32.06m },
                new AreaChartData { Timestamp = 1346191200000, Value = 31.96m },
                new AreaChartData { Timestamp = 1346277600000, Value = 31.46m },
                new AreaChartData { Timestamp = 1346364000000, Value = 31.27m },
                new AreaChartData { Timestamp = 1346709600000, Value = 31.43m },
                new AreaChartData { Timestamp = 1346796000000, Value = 32.26m },
                new AreaChartData { Timestamp = 1346882400000, Value = 32.79m },
                new AreaChartData { Timestamp = 1346968800000, Value = 32.46m },
                new AreaChartData { Timestamp = 1347228000000, Value = 32.13m },
                new AreaChartData { Timestamp = 1347314400000, Value = 32.43m },
                new AreaChartData { Timestamp = 1347400800000, Value = 32.42m },
                new AreaChartData { Timestamp = 1347487200000, Value = 32.81m },
                new AreaChartData { Timestamp = 1347573600000, Value = 33.34m },
                new AreaChartData { Timestamp = 1347832800000, Value = 33.41m },
                new AreaChartData { Timestamp = 1347919200000, Value = 32.57m },
                new AreaChartData { Timestamp = 1348005600000, Value = 33.12m },
                new AreaChartData { Timestamp = 1348092000000, Value = 34.53m },
                new AreaChartData { Timestamp = 1348178400000, Value = 33.83m },
                new AreaChartData { Timestamp = 1348437600000, Value = 33.41m },
                new AreaChartData { Timestamp = 1348524000000, Value = 32.90m },
                new AreaChartData { Timestamp = 1348610400000, Value = 32.53m },
                new AreaChartData { Timestamp = 1348696800000, Value = 32.80m },
                new AreaChartData { Timestamp = 1348783200000, Value = 32.44m },
                new AreaChartData { Timestamp = 1349042400000, Value = 32.62m },
                new AreaChartData { Timestamp = 1349128800000, Value = 32.57m },
                new AreaChartData { Timestamp = 1349215200000, Value = 32.60m },
                new AreaChartData { Timestamp = 1349301600000, Value = 32.68m },
                new AreaChartData { Timestamp = 1349388000000, Value = 32.47m },
                new AreaChartData { Timestamp = 1349647200000, Value = 32.23m },
                new AreaChartData { Timestamp = 1349733600000, Value = 31.68m },
                new AreaChartData { Timestamp = 1349820000000, Value = 31.51m },
                new AreaChartData { Timestamp = 1349906400000, Value = 31.78m },
                new AreaChartData { Timestamp = 1349992800000, Value = 31.94m },
                new AreaChartData { Timestamp = 1350252000000, Value = 32.33m },
                new AreaChartData { Timestamp = 1350338400000, Value = 33.24m },
                new AreaChartData { Timestamp = 1350424800000, Value = 33.44m },
                new AreaChartData { Timestamp = 1350511200000, Value = 33.48m },
                new AreaChartData { Timestamp = 1350597600000, Value = 33.24m },
                new AreaChartData { Timestamp = 1350856800000, Value = 33.49m },
                new AreaChartData { Timestamp = 1350943200000, Value = 33.31m },
                new AreaChartData { Timestamp = 1351029600000, Value = 33.36m },
                new AreaChartData { Timestamp = 1351116000000, Value = 33.40m },
                new AreaChartData { Timestamp = 1351202400000, Value = 34.01m },
                new AreaChartData { Timestamp = 1351638000000, Value = 34.02m },
                new AreaChartData { Timestamp = 1351724400000, Value = 34.36m },
                new AreaChartData { Timestamp = 1351810800000, Value = 34.39m },
                new AreaChartData { Timestamp = 1352070000000, Value = 34.24m },
                new AreaChartData { Timestamp = 1352156400000, Value = 34.39m },
                new AreaChartData { Timestamp = 1352242800000, Value = 33.47m },
                new AreaChartData { Timestamp = 1352329200000, Value = 32.98m },
                new AreaChartData { Timestamp = 1352415600000, Value = 32.90m },
                new AreaChartData { Timestamp = 1352674800000, Value = 32.70m },
                new AreaChartData { Timestamp = 1352761200000, Value = 32.54m },
                new AreaChartData { Timestamp = 1352847600000, Value = 32.23m },
                new AreaChartData { Timestamp = 1352934000000, Value = 32.64m },
                new AreaChartData { Timestamp = 1353020400000, Value = 32.65m },
                new AreaChartData { Timestamp = 1353279600000, Value = 32.92m },
                new AreaChartData { Timestamp = 1353366000000, Value = 32.64m },
                new AreaChartData { Timestamp = 1353452400000, Value = 32.84m },
                new AreaChartData { Timestamp = 1353625200000, Value = 33.40m },
                new AreaChartData { Timestamp = 1353884400000, Value = 33.30m },
                new AreaChartData { Timestamp = 1353970800000, Value = 33.18m },
                new AreaChartData { Timestamp = 1354057200000, Value = 33.88m },
                new AreaChartData { Timestamp = 1354143600000, Value = 34.09m },
                new AreaChartData { Timestamp = 1354230000000, Value = 34.61m },
                new AreaChartData { Timestamp = 1354489200000, Value = 34.70m },
                new AreaChartData { Timestamp = 1354575600000, Value = 35.30m },
                new AreaChartData { Timestamp = 1354662000000, Value = 35.40m },
                new AreaChartData { Timestamp = 1354748400000, Value = 35.14m },
                new AreaChartData { Timestamp = 1354834800000, Value = 35.48m },
                new AreaChartData { Timestamp = 1355094000000, Value = 35.75m },
                new AreaChartData { Timestamp = 1355180400000, Value = 35.54m },
                new AreaChartData { Timestamp = 1355266800000, Value = 35.96m },
                new AreaChartData { Timestamp = 1355353200000, Value = 35.53m },
                new AreaChartData { Timestamp = 1355439600000, Value = 37.56m },
                new AreaChartData { Timestamp = 1355698800000, Value = 37.42m },
                new AreaChartData { Timestamp = 1355785200000, Value = 37.49m },
                new AreaChartData { Timestamp = 1355871600000, Value = 38.09m },
                new AreaChartData { Timestamp = 1355958000000, Value = 37.87m },
                new AreaChartData { Timestamp = 1356044400000, Value = 37.71m },
                new AreaChartData { Timestamp = 1356303600000, Value = 37.53m },
                new AreaChartData { Timestamp = 1356476400000, Value = 37.55m },
                new AreaChartData { Timestamp = 1356562800000, Value = 37.30m },
                new AreaChartData { Timestamp = 1356649200000, Value = 36.90m },
                new AreaChartData { Timestamp = 1356908400000, Value = 37.68m },
                new AreaChartData { Timestamp = 1357081200000, Value = 38.34m },
                new AreaChartData { Timestamp = 1357167600000, Value = 37.75m },
                new AreaChartData { Timestamp = 1357254000000, Value = 38.13m },
                new AreaChartData { Timestamp = 1357513200000, Value = 37.94m },
                new AreaChartData { Timestamp = 1357599600000, Value = 38.14m },
                new AreaChartData { Timestamp = 1357686000000, Value = 38.66m },
                new AreaChartData { Timestamp = 1357772400000, Value = 38.62m },
                new AreaChartData { Timestamp = 1357858800000, Value = 38.09m },
                new AreaChartData { Timestamp = 1358118000000, Value = 38.16m },
                new AreaChartData { Timestamp = 1358204400000, Value = 38.15m },
                new AreaChartData { Timestamp = 1358290800000, Value = 37.88m },
                new AreaChartData { Timestamp = 1358377200000, Value = 37.73m },
                new AreaChartData { Timestamp = 1358463600000, Value = 37.98m },
                new AreaChartData { Timestamp = 1358809200000, Value = 37.95m },
                new AreaChartData { Timestamp = 1358895600000, Value = 38.25m },
                new AreaChartData { Timestamp = 1358982000000, Value = 38.10m },
                new AreaChartData { Timestamp = 1359068400000, Value = 38.32m },
                new AreaChartData { Timestamp = 1359327600000, Value = 38.24m },
                new AreaChartData { Timestamp = 1359414000000, Value = 38.52m },
                new AreaChartData { Timestamp = 1359500400000, Value = 37.94m },
                new AreaChartData { Timestamp = 1359586800000, Value = 37.83m },
                new AreaChartData { Timestamp = 1359673200000, Value = 38.34m },
                new AreaChartData { Timestamp = 1359932400000, Value = 38.10m },
                new AreaChartData { Timestamp = 1360018800000, Value = 38.51m },
                new AreaChartData { Timestamp = 1360105200000, Value = 38.40m },
                new AreaChartData { Timestamp = 1360191600000, Value = 38.07m },
                new AreaChartData { Timestamp = 1360278000000, Value = 39.12m },
                new AreaChartData { Timestamp = 1360537200000, Value = 38.64m },
                new AreaChartData { Timestamp = 1360623600000, Value = 38.89m },
                new AreaChartData { Timestamp = 1360710000000, Value = 38.81m },
                new AreaChartData { Timestamp = 1360796400000, Value = 38.61m },
                new AreaChartData { Timestamp = 1360882800000, Value = 38.63m },
                new AreaChartData { Timestamp = 1361228400000, Value = 38.99m },
                new AreaChartData { Timestamp = 1361314800000, Value = 38.77m },
                new AreaChartData { Timestamp = 1361401200000, Value = 38.34m },
                new AreaChartData { Timestamp = 1361487600000, Value = 38.55m },
                new AreaChartData { Timestamp = 1361746800000, Value = 38.11m },
                new AreaChartData { Timestamp = 1361833200000, Value = 38.59m },
                new AreaChartData { Timestamp = 1361919600000, Value = 39.60m }
            };
            
            return View(model);
        }
    }
}