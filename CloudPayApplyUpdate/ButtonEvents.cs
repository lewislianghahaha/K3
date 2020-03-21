using System;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Core.List.PlugIn;

namespace CloudPayApplyUpdate
{
    public class ButtonEvents :AbstractListPlugIn
    {
        Generate generate=new Generate();

        public override void BarItemClick(BarItemClickEventArgs e)
        {
            //定义主键变量(用于收集所选中的行主键值)
            var fidlist = string.Empty;

            //订单退回操作
            base.BarItemClick(e);

            //付款申请单
            if (e.BarItemKey=="tbPayApply")
            {
                //获取列表上通过复选框勾选的记录
                var selectedRows = this.ListView.SelectedRowsInfo;
                //通过循环将选中行的主键进行收集
                foreach (var row in selectedRows)
                {
                    if (string.IsNullOrEmpty(fidlist))
                    {
                        fidlist = Convert.ToString(row.PrimaryKeyValue);
                    }
                    else
                    {
                        fidlist += "," + Convert.ToString(row.PrimaryKeyValue);
                    }
                }

                //根据所获取的单号进行更新
               // generate.UpdateK3Record("");

                //输出
                View.ShowMessage($"{fidlist}");
            }
        }


    }
}
