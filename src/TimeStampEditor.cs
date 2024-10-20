// csc /target:winexe TimeStampEditor.cs

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using System.Reflection;


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
    public FileDateTimeUpdaterForm()
    {
        // [1] メインフォーム定義
        this.Text = "TimeStampEditor";
        this.Size = new System.Drawing.Size(230,380);
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.TopMost = true;

        // [2] ラベル ①日付指定メッセージ
        lblDateTimePicker = new Label();
        lblDateTimePicker.Text = "①日時を指定してください。";
        lblDateTimePicker.Size = new System.Drawing.Size(220,15);
        lblDateTimePicker.Location = new System.Drawing.Point(10,10);
        this.Controls.Add(lblDateTimePicker);

        // [3] 日付ピッカー
        datePicker = new DateTimePicker();
        datePicker.Format = DateTimePickerFormat.Short;
        datePicker.Location = new System.Drawing.Point(10,30);
        this.Controls.Add(datePicker);
        
        // [4] 時刻ピッカー
        timePicker = new DateTimePicker();
        timePicker.Format = DateTimePickerFormat.Time;
        timePicker.Location = new System.Drawing.Point(10,50);
        this.Controls.Add(timePicker);

        // [5] ラベル ②対象を選択してください(複数可)
        lblChkList = new Label();
        lblChkList.Text = "②対象を選択してください(複数可)";
        lblChkList.Size = new System.Drawing.Size(220,15);
        lblChkList.Location = new System.Drawing.Point(10,85);
        this.Controls.Add(lblChkList);

        // [6] チェックボックス 作成日時
        chkCreation = new CheckBox();
        chkCreation.Text = "作成日時";
        chkCreation.Location = new System.Drawing.Point(10,100);
        this.Controls.Add(chkCreation);

        // [7] チェックボックス 更新日時
        chkModificaion = new CheckBox();
        chkModificaion.Text = "更新日時";
        chkModificaion.Location = new System.Drawing.Point(10,120);
        this.Controls.Add(chkModificaion);

        // [8] チェックボックス アクセス日時
        chkAccess = new CheckBox();
        chkAccess.Text = "アクセス日時";
        chkAccess.Location = new System.Drawing.Point(10,140);
        this.Controls.Add(chkAccess);

        // [9] ラベル ③ファイルをドラッグアンドドロップ(複数可)
        lblDragDrop = new Label();
        lblDragDrop.Text = "③ファイルをドラッグアンドドロップ(複数可)";
        lblDragDrop.Size = new System.Drawing.Size(220,15);
        lblDragDrop.Location = new System.Drawing.Point(10,170);
        this.Controls.Add(lblDragDrop);


        // [10] ラベル ここにファイルをドラッグアンドドロップ
        lblDragDropShape = new Label();
        lblDragDropShape.Text = "ここにファイルをドラッグアンドドロップ";
        lblDragDropShape.Size = new System.Drawing.Size(220,15);
        lblDragDropShape.Location = new System.Drawing.Point(30,250);
        this.Controls.Add(lblDragDropShape);

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
        try
        {
            // 日時組み立て
            DateTime selectedDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            
            // ドロップファイル組み立て
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // 繰り返し処理
            foreach (string file in files)
            {
                // 作成日時変更
                if(chkCreation.Checked)
                {
                    File.SetCreationTime(file, selectedDate);
                }

                // 更新日時変更
                if(chkModificaion.Checked)
                {
                    File.SetLastWriteTime(file, selectedDate);
                }

                // アクセス日時変更
                if(chkAccess.Checked)
                {
                    File.SetLastAccessTime(file, selectedDate);
                }
            }
        }
        catch(Exception)
        {
            this.BringToFront();
            this.Activate();
            MessageBox.Show("処理が異常終了しました。");
        }
        this.BringToFront();
        this.Activate();
        MessageBox.Show("処理が完了しました。");
    }

    // Main処理
    [STAThread]
    public static void Main(){
        Application.EnableVisualStyles();
        Application.Run(new FileDateTimeUpdaterForm());
    }
    
}