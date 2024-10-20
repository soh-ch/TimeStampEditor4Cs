// csc /target:winexe TimeStampEditor.cs

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using System.Refrection;


public FileDateTimeUpdaterForm : Form
{
    private DateTimePicker datePicker;
    private DateTimePicker timePicker;
    private CheckBox chkCreation;
    private CheckBox chkModificaion;
    private CheckBox chkAccess;
    private Label lblDateTimePicker;
    private Label lblChkList;
    private Label lblDragDrop;
    private Label lblDragDropShape;
    
    // ユーザフォーム定義
    public FileDatteTimeUpdaterForm()
    {
        // [1] メインフォーム定義
        this.Text = "TimeStampEditor"
        this.Size = new Sysetm.Drawing.Size(230,380)
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.TopMost = true;

        // [2] ラベル 日付指定メッセージ
        lblDateTimePicker = new Label();
        lblDateTimePicker.Text = "①日時を指定してください。";
        lblDateTimePicker.Size = new System.Drawing.Size(220,15);
        lblDateTimePicker.Location = new System.Drawing.Point(10,10,);
        tthis.Controls.Add(lblDateTimePicker);

    }
}