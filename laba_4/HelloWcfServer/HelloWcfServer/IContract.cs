using System.ServiceModel;


namespace HelloWcfServer
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        byte[] Say(string input);
    }
}
