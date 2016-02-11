using Common.Attributes;
using VdfFactoring.Models;

namespace VdfFactoring.ViewModels
{
    public class DataGridTestModel
    {

        [DataGrid(ShowFooter = true, Name = "here goes my table name")]
        public DataGridModel SampleGrid { get; set; }
    }
}