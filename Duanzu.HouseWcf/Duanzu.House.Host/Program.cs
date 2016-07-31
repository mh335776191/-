using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.Contract.HouseInterface;
using Duanzu.House.Service;
using Duanzu.TXCommons.Common;

namespace Duanzu.House.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var MaxConcurrentCalls = ConfigurationManager.AppSettings["MaxConcurrentCalls"];
            var MaxConcurrentInstances = ConfigurationManager.AppSettings["MaxConcurrentInstances"];
            var MaxConcurrentSessions = ConfigurationManager.AppSettings["MaxConcurrentSessions"];

            var hostsets = ConfigurationManager.AppSettings["HostSetJson"];
            var hostsetmodels = hostsets.JSONStringToList<HostSetJson>();

            if (hostsetmodels != null && hostsetmodels.Count > 0)
            {

                foreach (var hostset in hostsetmodels)
                {
                    ServiceHost host = new ServiceHost(typeof(HouseServices), new Uri(hostset.Basic));
                    #region
                    if (!string.IsNullOrEmpty(MaxConcurrentCalls) || !string.IsNullOrEmpty(MaxConcurrentInstances) || !string.IsNullOrEmpty(MaxConcurrentCalls))
                    {
                        ServiceThrottlingBehavior throttlingBehavior = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                        if (null == throttlingBehavior)
                        {
                            throttlingBehavior = new ServiceThrottlingBehavior();
                            host.Description.Behaviors.Add(throttlingBehavior);
                        }
                        if (!string.IsNullOrEmpty(MaxConcurrentCalls))
                        {
                            throttlingBehavior.MaxConcurrentCalls = Convert.ToInt32(MaxConcurrentCalls);
                        }
                        if (!string.IsNullOrEmpty(MaxConcurrentInstances))
                        {
                            throttlingBehavior.MaxConcurrentInstances = Convert.ToInt32(MaxConcurrentInstances);
                        }
                        if (!string.IsNullOrEmpty(MaxConcurrentSessions))
                        {
                            throttlingBehavior.MaxConcurrentSessions = Convert.ToInt32(MaxConcurrentSessions);
                        }
                    }
                    #endregion
                    //可以配置多个wcf服务 host1 host2
                    //baseurl配置
                    host.AddServiceEndpoint(typeof(IHouseServicersContract), new BasicHttpBinding(), new Uri(hostset.Basic));
                    //tcp配置
                    //host.AddServiceEndpoint(typeof(ICalculator), new NetTcpBinding(), "net.tcp://192.168.1.105:1921/HomeServieTcp");
                    host.AddServiceEndpoint(typeof(IHouseServicersContract), new NetTcpBinding(), hostset.Tcp);
                    //公布元数据
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
                    host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), hostset.Mex);
                    if (host.State != CommunicationState.Opening)
                        host.Open();
                    Console.WriteLine("服务器启动成功，正在监控中！" + hostset.Basic);

                }
                Console.Read();
            }          
        }
    }
    class HostSetJson
    {
        public string Basic { get; set; }
        public string Tcp { get; set; }
        public string Mex { get; set; }
    }
}