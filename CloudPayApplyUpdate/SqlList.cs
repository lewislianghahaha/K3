namespace CloudPayApplyUpdate
{
    public class SqlList
    {
        private string _result;

        public string UpdateRecord(string ordernolist)
        {
            _result = $@"
                            UPDATE dbo.T_CN_PAYAPPLY SET F_YTC_TEXT='付款完成'
					        WHERE FID in ({ordernolist}) and FDOCUMENTSTATUS='C'
                        ";

            return _result;
        }
    }
}
