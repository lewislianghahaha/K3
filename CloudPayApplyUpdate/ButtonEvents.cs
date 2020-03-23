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
            //获取当前登录用户信息ID
            var currUserId = this.Context.UserId;  
            //付款申请单(注:只有当前用户是‘易建青’才可以使用)
            if (e.BarItemKey=="tbPayApply" && currUserId== 680335)
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
                generate.UpdateK3Record(fidlist);

                //输出
                View.ShowMessage("已完成更新");
            }
        }


    }
}
