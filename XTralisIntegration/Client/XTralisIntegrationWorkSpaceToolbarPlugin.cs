using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace XTralisIntegration.Client
{
    class XTralisIntegrationWorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public XTralisIntegrationWorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "XTralisIntegration";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    class XTralisIntegrationWorkSpaceToolbarPlugin : WorkSpaceToolbarPlugin
    {
        public XTralisIntegrationWorkSpaceToolbarPlugin()
        {
        }

        public override Guid Id
        {
            get { return XTralisIntegrationDefinition.XTralisIntegrationWorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "XTralisIntegration"; }
        }

        public override void Init()
        {
            // TODO: remove below check when XTralisIntegrationDefinition.XTralisIntegrationWorkSpaceToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for XTralisIntegrationWorkSpaceToolbarPluginId!");
            }

            WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, XTralisIntegrationDefinition.XTralisIntegrationWorkSpacePluginId };
            WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new XTralisIntegrationWorkSpaceToolbarPluginInstance();
        }
    }
}
