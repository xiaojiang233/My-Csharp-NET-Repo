using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPSTester
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        private int testDuration;
        private int clickCount;
        public Form1()
        {
            InitializeComponent();

        }

        private void InitializeComboBox()
        {
            // 添加可选的测试时间选项
            comboBoxDuration.Items.Add("1秒");
            comboBoxDuration.Items.Add("5秒");
            comboBoxDuration.Items.Add("10秒");
            comboBoxDuration.Items.Add("1分钟");

            // 默认选择第一项
            comboBoxDuration.SelectedIndex = 0;
        }

        private void CPSBtn_Click(object sender, EventArgs e)
        {
            if (stopwatch == null || !stopwatch.IsRunning)
            {
                // 开始测试
                testDuration = GetTestDuration();
                clickCount = 0;
                StartTest();
            }
            else
            {
                // 结束测试
                EndTest();
            }
        }

        private int GetTestDuration()
        {
            string selectedDuration = comboBoxDuration.SelectedItem.ToString();
            switch (selectedDuration)
            {
                case "1秒":
                    return 1000;
                case "5秒":
                    return 5000;
                case "10秒":
                    return 10000;
                case "1分钟":
                    return 60000;
                default:
                    return 0;
            }
        }

        private void StartTest()
        {
            stopwatch = Stopwatch.StartNew();
            CPSBtn.Text = "CLICK";
            comboBoxDuration.Enabled = false;

            // 更新剩余时间标签
            UpdateRemainingTimeLabel();

            // 在指定的测试时间后停止测试
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.Sleep(testDuration);
                EndTest();
            });
        }

        private void EndTest()
        {
            stopwatch.Stop();
            CPSBtn.Text = "Click to start test";
            comboBoxDuration.Enabled = true;

            // 计算CPS并显示结果
            double cps = CalculateCPS();
            lblCPS.Text = $"CPS: {cps}";

            // 显示已点击的次数
            lblClickCount.Text = $"Clicks: {clickCount}";

            // 清空剩余时间标签
            lblRemainingTime.Text = string.Empty;
        }

        private double CalculateCPS()
        {
            double elapsedTimeInSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
            double cps = clickCount / elapsedTimeInSeconds;
            return cps;
        }

        private void UpdateRemainingTimeLabel()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                while (stopwatch.IsRunning)
                {
                    TimeSpan remainingTime = TimeSpan.FromMilliseconds(testDuration) - stopwatch.Elapsed;
                    lblRemainingTime.Invoke((MethodInvoker)(() => lblRemainingTime.Text = $"Remaining Time: {remainingTime:mm\\:ss}"));
                    Thread.Sleep(100);
                }
            });
        }

        private void CPSBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (stopwatch != null && stopwatch.IsRunning)
            {
                clickCount++;
                lblClickCount.Text = $"Clicks: {clickCount}";
            }
        }
    }
}
