// csc /target:winexe TimeStampEditor.cs

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using System.Refrection;


public class FileDateTimeUpdaterForm : Form
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

        // [2] ラベル ①日付指定メッセージ
        lblDateTimePicker = new Label();
        lblDateTimePicker.Text = "①日時を指定してください。";
        lblDateTimePicker.Size = new System.Drawing.Size(220,15);
        lblDateTimePicker.Location = new System.Drawing.Point(10,10,);
        tthis.Controls.Add(lblDateTimePicker);

        // [3] 日付ピッカー
        
        // [4] 時刻ピッカー

        // [5] ラベル ②対象を選択してください(複数可)


        // [6] チェックボックス 作成日時

        // [7] チェックボックス 更新日時

        // [8] チェックボックス アクセス日時

        // [9] ラベル ③ファイルをドラッグアンドドロップ(複数可)

        // [10] ラベル ここにファイルをドラッグアンドドロップ


        // [11] ドロップ許容
        this.AllowDrop = true;
        this.DragEnter += new DragEventHandler(DragDropLabel_DragEnter);
        this.DragDrop += new DragEventHandler(DragDropLabel_DragDrop);
    }

    // カーソルがフォームエリアに入ったときの挙動
    private void DragDropLabel_DragEnter(object Sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.All;
    }

    // ドラッグアンドドロップしたときの処理
    private void DragDropLabel_DragDrop(object Sender, DragEventArgs e)
    {

    }

    // Main処理
    [STAThread]
    public static void Main(){
        Application.EnableVisualStyles():
        Application.Run(new FileDateTimeUpdaterForm());
    }
    
}