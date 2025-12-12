namespace BWDotNetTrainingBatch5.ChartWebApp.Models;

/* Pie Chart */
public class ApexChartPieChartModel
{
    public int[] Series { get; set; }
    public string[] Labels { get; set; } 
}

/* Mixed Chart */
public class ApexChartMixedChartModel
{
    public List<SeriesData> Series { get; set; }
    public string[] Labels { get; set; }
}

public class SeriesData
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int[] Data { get; set; }
}

/* Candle Stick Chart */
public class ApexChartCandlestickModel
{
    public List<CandlestickSeriesData> CandlestickData { get; set; }
    public List<LineSeriesData> LineData { get; set; }
}

public class CandlestickSeriesData
{
    public long X { get; set; }
    public decimal[] Y { get; set; } // [Open, High, Low, Close]
}

public class LineSeriesData
{
    public long X { get; set; }
    public decimal Y { get; set; }
}

/* Column Chart */
public class ColumnChartModel
{
    public List<ColumnSeriesData> Series { get; set; }
    public string[] Categories { get; set; }
}

public class ColumnSeriesData
{
    public string Name { get; set; }
    public int[] Data { get; set; }
}

/* Area Chart */
public class ApexChartAreaChartModel
{
    public List<AreaChartData> Data { get; set; }
}

public class AreaChartData
{
    public long Timestamp { get; set; }
    public decimal Value { get; set; }
}

