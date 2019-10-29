using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace DbUtility
{
    public partial class frmBackupSetting : DevExpress.XtraEditors.XtraForm
    {
        private string on;
        private string selectedDays = string.Empty; //contains list of days selected on Day/Week backup option

        SettingBL oSettingBL;
        BackupSetting oBackupSetting;

        Dictionary<int, string> customDays;

        public frmBackupSetting()
        {
            InitializeComponent();

            oSettingBL = new SettingBL();
            oBackupSetting = new BackupSetting();

            customDays = new Dictionary<int,string>();

            cboBackupPeriod_SelectedIndexChanged(null, null);

            btnSunday.LookAndFeel.UseDefaultLookAndFeel = false;
            btnSunday.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            Populate();
        }

        private void Populate()
        {
            try
            {
                oBackupSetting = oSettingBL.GetBackupSetting();
                if (oBackupSetting != null)
                {
                    if (oBackupSetting.On == "day/week")
                    {
                        dtEveryDayWeekTime.EditValue = oBackupSetting.Time;

                        List<string> _days = oSettingBL.GetBackupDays(oBackupSetting.Day);
                        
                        foreach (var _controls in layoutControl1.Controls)
                        {
                            if (_controls is CheckButton)
                            {
                                var _btn = _controls as CheckButton;
                                foreach (var _d in _days)
                                {
                                    if (_btn.Text == _d)
                                    {
                                        _btn.Checked = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (oBackupSetting.On == "every month")
                    {
                        cboEveryMonthDay.EditValue = oBackupSetting.Day;
                        dtEveryMonthTime.EditValue = oBackupSetting.Time;
                    }
                    else if (oBackupSetting.On == "every year")
                    {
                        cboEveryYearMonth.EditValue = oBackupSetting.Month;
                        cboEveryYearDay.EditValue = oBackupSetting.Day;
                        dtEveryYearTime.EditValue = oBackupSetting.Time;
                    }

                    txtBackupLocation.Text = oBackupSetting.BackupLocation;
                    List<string> _cboOptions = new List<string>();
                    foreach (var i in cboBackupPeriod.Properties.Items)
                        _cboOptions.Add(i.ToString().ToLower());

                    cboBackupPeriod.SelectedIndex = _cboOptions.IndexOf(oBackupSetting.On);
                }
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void HideShow(string option)
        {
            if (option == "day/week")
            {
                layGrpDayWeek.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layGrpEveryMonth.Visibility = layGrpEveryYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Size = new Size(422, 260);
            }
            else if (option == "every month")
            {
                layGrpEveryMonth.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layGrpDayWeek.Visibility = layGrpEveryYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Size = new Size(422, 250);
            }
            else if (option == "every year")
            {
                layGrpEveryYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layGrpDayWeek.Visibility = layGrpEveryMonth.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Size = new Size(422, 250);
            }
        }

        private void cboBackupPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                on = cboBackupPeriod.SelectedItem.ToString().ToLower();

                HideShow(on);
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Please try agin. \n" + ex.Message, "error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBackupPeriod.SelectedItem != null && !string.IsNullOrEmpty(txtBackupLocation.Text))
                {
                    oBackupSetting = null;

                    #region Backup on day/week
                    if (cboBackupPeriod.SelectedIndex == 0) //day/week selected
                    {
                        if (customDays.Count <= 0 || dtEveryDayWeekTime.EditValue == null)
                            DbUtilityHelper.DisplayMessageBox("Please specify the day(s) of the week to take backup on", "warning");
                        else
                        {
                            oBackupSetting = new BackupSetting()
                            {
                                Month = string.Empty,
                                Day = selectedDays,
                                Time = dtEveryDayWeekTime.Text
                            };
                        }
                    }
                    #endregion
                    
                    #region Backup on every month
                    else if (cboBackupPeriod.SelectedIndex == 1) //month selected
                    {
                        if (cboEveryMonthDay.SelectedItem == null || dtEveryDayWeekTime.EditValue == null)
                            DbUtilityHelper.DisplayMessageBox("Please specify the day and time of the month to take backup", "warning");
                        else
                        {
                            oBackupSetting = new BackupSetting()
                            {
                                Month = string.Empty,
                                Day = cboEveryMonthDay.EditValue.ToString(),
                                Time = dtEveryMonthTime.Text
                            };
                        }
                    }
                    #endregion
                    
                    #region Backup on every year
                    else if (cboBackupPeriod.SelectedIndex == 2) //year selected
                    {
                        if (cboEveryYearMonth.SelectedItem == null || cboEveryYearDay.SelectedItem == null || dtEveryYearTime.EditValue == null)
                            DbUtilityHelper.DisplayMessageBox("Please specify month, day and time of the year to take backup", "warning");
                        else
                        {
                            oBackupSetting = new BackupSetting()
                            {
                                Month = cboEveryYearMonth.EditValue.ToString(),
                                Day = cboEveryYearDay.EditValue.ToString(),
                                Time = dtEveryYearTime.Text
                            };
                        }
                    }
                    #endregion

                    if (oBackupSetting != null)
                    {
                        oBackupSetting.On = on;
                        oBackupSetting.BackupLocation = txtBackupLocation.Text.Trim();

                        if (oSettingBL.Add(oBackupSetting))
                        {
                            DbUtilityHelper.DisplayMessageBox("Setting successfully saved", "information");
                            this.Close();
                        }
                        else
                            DbUtilityHelper.DisplayMessageBox("Setting could not be saved. Please try again.", "error");
                    }
                }
                else
                    DbUtilityHelper.DisplayMessageBox("Please select backup period", "warning");
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnBackupLocation_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.ShowDialog();
                if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                    txtBackupLocation.Text = folderBrowserDialog.SelectedPath;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void dayOfWeek_Clicked(object sender, EventArgs e)//string dayOfTheWeek, bool isDayToAdd)
        {
            try
            {
                CheckButton _chkBtn = (CheckButton)sender;
                selectedDays = string.Empty;

                if (_chkBtn.Checked)
                {
                    customDays.Add(Convert.ToInt32(_chkBtn.Tag), _chkBtn.Text);
                    _chkBtn.Appearance.BackColor = Color.Gold;
                    _chkBtn.Appearance.BackColor2 = Color.Goldenrod;
                }
                else
                {
                    customDays.Remove(Convert.ToInt32(_chkBtn.Tag));
                    _chkBtn.Appearance.BackColor = _chkBtn.Appearance.BackColor2 = Color.Transparent;
                }
                

                var _list = customDays.Keys.ToList();
                _list.Sort();

                foreach (var key in _list)
                {
                    if (!string.IsNullOrEmpty(selectedDays))
                        selectedDays = selectedDays + "," + customDays[key];
                    else
                        selectedDays = customDays[key];
                }

                //DbUtilityHelper.DisplayMessageBox(_selectedDays, "information");
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Days selected could not be set. Try again later. \n" + ex.Message, "error");
            }
        }
    }
}