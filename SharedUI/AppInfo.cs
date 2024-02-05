
namespace SharedUI;

public class AppInfo : IAppInfo
{
    private APIClient _apiClient { get; set; }
    private IAppKeys _appKeys { get; set; }

    CancellationTokenSource? cancellationTokenSource;
    CancellationToken cancToken => (cancellationTokenSource ??= new()).Token;

    public AppInfo(APIClient apiClient, IAppKeys appKeys)
    {
        _apiClient = apiClient; _appKeys = appKeys;

        SetMasterData();
        SetLoginBased();
    }

    // private Lazy<ValueTask<IEnumerable<SurveyTypes.SurveyType>>> _SurveyTypes;
    // public ValueTask<IEnumerable<SurveyTypes.SurveyType>> SurveyTypes => _SurveyTypes.Value;

    // private Lazy<ValueTask<IEnumerable<(long? uin, string code, string desc, LiveInfos.LiveInfo liveinfo)>>> _LiveSurveys;
    // public ValueTask<IEnumerable<(long? uin, string code, string desc, LiveInfos.LiveInfo liveinfo)>> LiveSurveys => _LiveSurveys.Value;

    public void SetMasterData()
    {
        // _SurveyTypes = new(async () => (await _apiClient.Read<SysParams<SurveyTypes>>(APIList.SysParams.Description(), new SysParamsReadParams
        // {
        //     systype = "surveytypes"
        // }, cancToken))?.First().sysvalue.value ?? Enumerable.Empty<SurveyTypes.SurveyType>(), true);
    }

    public void SetLoginBased()
    {
        // _LiveSurveys = new(async () =>
        // {
        //     var emailId = await _appKeys.Get<string>(KeyName.EmailId);

        //     return (from st in (await SurveyTypes)
        //             from li in st.liveinfo.value
        //             where DateTime.Now >= li.startdate && DateTime.Now <= li.enddate && li.emailids.Contains(emailId)
        //             select (st.uin, st.code, st.desc, liveinfo: li));
        // });
    }
}
