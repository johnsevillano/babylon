using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using Babylon.Site.Providers.Mocks;


namespace Babylon.Site.Providers
{
    public class ProvidersFactory
    {
        static RunMode _runMode;

        /// <summary>
        /// 
        /// </summary>
        public ProvidersFactory()
        {
            string strRunMode = System.Configuration.ConfigurationManager.AppSettings["RunMode"];

            RunMode result;
            if (Enum.TryParse<RunMode>(strRunMode, out result))
            {
                _runMode = result;
            }
            else
            {
                _runMode = RunMode.Real;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IGroupsProvider BuildGroupsProvider()
        {
            IGroupsProvider provider;

            if (_runMode == RunMode.Real)
            {
                provider = new GroupsProvider();
            }
            else
            {
                provider = new MockGroupsProvider();
            }

            return provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMediaItemsProvider BuildMediaItemsProvider()
        {
            IMediaItemsProvider provider;

            if (_runMode == RunMode.Real)
            {
                provider = new MediaItemsProvider();
            }
            else
            {
                provider = new MockMediaItemsProvider();
            }

            return provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMessagesProvider BuildMessagesProvider()
        {
            IMessagesProvider provider;

            if (_runMode == RunMode.Real)
            {
                provider = new MessagesProvider();
            }
            else
            {
                provider = new MockMessagesProvider();
            }

            return provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public INewsProvider BuildNewsProvider()
        {
            INewsProvider provider;

            if (_runMode == RunMode.Real)
            {
                provider = new NewsProvider();
            }
            else
            {
                provider = new MockNewsProvider();
            }

            return provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IProfilesProvider BuildProfilesProvider()
        {
            IProfilesProvider provider;

            if (_runMode == RunMode.Real)
            {
                provider = new ProfilesProvider();
            }
            else
            {
                provider = MockProfilesProvider.Instance;
            }

            return provider;
        }

    }

    enum RunMode
    {
        Test,
        Real
    }
}