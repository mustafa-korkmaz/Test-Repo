
using System;
using Common.Helpers;
using Common.UIElements;
using Common.Attributes;

namespace VdfFactoring.ViewModels
{
    public class ComplexPersonViewModel
    {
        [DataGridColumn("Ücret", DataFormat = ColumnDataFormat.Money)]
        public double Salary { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        [DataGridColumn(Visible = false)]
        public int Id { get; set; }

        [DataGridColumn("Tarih", DataFormat = ColumnDataFormat.Date)]
        public DateTime DayOfBirth { get; set; }

        [DataGridColumn("Değişitirilme Tarihi", DataFormat = ColumnDataFormat.Date)]
        public DateTime ModifiedAt { get; set; }

        [DataGridColumn("External Link", DataType = ColumnDataType.LinkButton)]
        public LinkButton Anchor { get; set; }

        [DataGridColumn("Image Link", DataType = ColumnDataType.ImageButton)]
        public ImageButton Image { get; set; }

    }

    public class SimplePersonViewModel
    {
        [DataGridColumn("Ücret", DataFormat = ColumnDataFormat.Money)]
        public double Salary { get; set; }

        [DataGridColumn("İsim", DataFormat = ColumnDataFormat.Default)]
        public string Name { get; set; }

        [DataGridColumn("Cinsiyet")]
        public string Gender { get; set; }

        [DataGridColumn("id bilgisi",Visible=false)]
        public int Id { get; set; }

        [DataGridColumn("Doğum Tarihi", DataFormat = ColumnDataFormat.Date)]
        public string BirthDate { get; set; }

        [DataGridColumn("Değitirme Tarihi", DataFormat = ColumnDataFormat.Date)]
        public string ModifiedDate { get; set; }

    }
}