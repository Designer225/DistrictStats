using System;
using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;
using System.Timers;

namespace DistrictStats
{
    public class DistrictStatsPanel : UIPanel
    {
        public bool displayRequested;
        private bool isShowing;
        private int updateCount;

        UILabel title;

        UISprite iconToolbarIconElectricity;
        UISprite iconToolbarIconWaterAndSewage;
        UISprite iconToolbarIconGarbage;
        UISprite iconInfoIconHeating;
        UISprite iconInfoIconOutsideConnection;

        UISlider sliderToolbarIconElectricity;
        UISlider sliderToolbarIconWaterAndSewage;
        UISlider sliderToolbarIconGarbage;
        UISlider sliderInfoIconHeating;
        UILabel labelImport;
        UILabel labelExport;

        public void CreatePanel()
        {
            // icons
            iconToolbarIconElectricity = AddUIComponent<UISprite>();
            iconToolbarIconElectricity.spriteName = "ToolbarIconElectricity";
            iconToolbarIconElectricity.name = "Icon";
            iconToolbarIconElectricity.size = new Vector2(20, 20);
            iconToolbarIconElectricity.relativePosition = new Vector3(5, 45);
            iconToolbarIconElectricity.BringToFront();

            iconToolbarIconWaterAndSewage = AddUIComponent<UISprite>();
            iconToolbarIconWaterAndSewage.spriteName = "ToolbarIconWaterAndSewage";
            iconToolbarIconWaterAndSewage.name = "Icon";
            iconToolbarIconWaterAndSewage.size = new Vector2(20, 20);
            iconToolbarIconWaterAndSewage.relativePosition = new Vector3(5, 70);
            iconToolbarIconWaterAndSewage.BringToFront();

            iconToolbarIconGarbage = AddUIComponent<UISprite>();
            iconToolbarIconGarbage.spriteName = "ToolbarIconGarbage";
            iconToolbarIconGarbage.name = "Icon";
            iconToolbarIconGarbage.size = new Vector2(20, 20);
            iconToolbarIconGarbage.relativePosition = new Vector3(5, 95);
            iconToolbarIconGarbage.BringToFront();

            iconInfoIconHeating = AddUIComponent<UISprite>();
            iconInfoIconHeating.spriteName = "InfoIconHeating";
            iconInfoIconHeating.name = "Icon";
            iconInfoIconHeating.size = new Vector2(20, 20);
            iconInfoIconHeating.relativePosition = new Vector3(5, 120);
            iconInfoIconHeating.BringToFront();

            iconInfoIconOutsideConnection = AddUIComponent<UISprite>();
            iconInfoIconOutsideConnection.spriteName = "InfoIconOutsideConnections";
            iconInfoIconOutsideConnection.name = "Icon";
            iconInfoIconOutsideConnection.size = new Vector2(20, 20);
            iconInfoIconOutsideConnection.relativePosition = new Vector3(5, 145);
            iconInfoIconOutsideConnection.BringToFront();

            // sliders
            sliderToolbarIconElectricity = AddUIComponent<UISlider>();
            sliderToolbarIconElectricity.name = "sliderToolbarIconElectricity";
            sliderToolbarIconElectricity.cachedName = "sliderToolbarIconElectricity";
            sliderToolbarIconElectricity.size = new Vector2(150, 10);
            sliderToolbarIconElectricity.relativePosition = new Vector3(40, 50);
            sliderToolbarIconElectricity.BringToFront();
            sliderToolbarIconElectricity.backgroundSprite = "MeterBackground";
            sliderToolbarIconElectricity.minValue = 0f;
            sliderToolbarIconElectricity.maxValue = 1.9f;
            sliderToolbarIconElectricity.stepSize = 0.01f;
            sliderToolbarIconElectricity.value = 0f;
            sliderToolbarIconElectricity.thumbObject = AddUIComponent<UISprite>();
            (sliderToolbarIconElectricity.thumbObject as UISprite).spriteName = "MeterIndicator";
            sliderToolbarIconElectricity.thumbObject.name = "Thumb";

            sliderToolbarIconWaterAndSewage = AddUIComponent<UISlider>();
            sliderToolbarIconWaterAndSewage.name = "sliderToolbarIconWaterAndSewage";
            sliderToolbarIconWaterAndSewage.cachedName = "sliderToolbarIconWaterAndSewage";
            sliderToolbarIconWaterAndSewage.size = new Vector2(150, 10);
            sliderToolbarIconWaterAndSewage.relativePosition = new Vector3(40, 75);
            sliderToolbarIconWaterAndSewage.BringToFront();
            sliderToolbarIconWaterAndSewage.backgroundSprite = "MeterBackground";
            sliderToolbarIconWaterAndSewage.minValue = 0f;
            sliderToolbarIconWaterAndSewage.maxValue = 1.9f;
            sliderToolbarIconWaterAndSewage.stepSize = 0.01f;
            sliderToolbarIconWaterAndSewage.value = 0f;
            sliderToolbarIconWaterAndSewage.thumbObject = AddUIComponent<UISprite>();
            (sliderToolbarIconWaterAndSewage.thumbObject as UISprite).spriteName = "MeterIndicator";
            sliderToolbarIconWaterAndSewage.thumbObject.name = "Thumb";

            sliderToolbarIconGarbage = AddUIComponent<UISlider>();
            sliderToolbarIconGarbage.name = "sliderToolbarIconGarbage";
            sliderToolbarIconGarbage.cachedName = "sliderToolbarIconGarbage";
            sliderToolbarIconGarbage = AddUIComponent<UISlider>();
            sliderToolbarIconGarbage.size = new Vector2(150, 10);
            sliderToolbarIconGarbage.relativePosition = new Vector3(40, 100);
            sliderToolbarIconGarbage.BringToFront();
            sliderToolbarIconGarbage.backgroundSprite = "MeterBackground";
            sliderToolbarIconGarbage.minValue = 0f;
            sliderToolbarIconGarbage.maxValue = 1.9f;
            sliderToolbarIconGarbage.stepSize = 0.01f;
            sliderToolbarIconGarbage.value = 0f;
            sliderToolbarIconGarbage.thumbObject = AddUIComponent<UISprite>();
            (sliderToolbarIconGarbage.thumbObject as UISprite).spriteName = "MeterIndicator";
            sliderToolbarIconGarbage.thumbObject.name = "Thumb";

            sliderInfoIconHeating = AddUIComponent<UISlider>();
            sliderInfoIconHeating.name = "sliderInfoIconHeating";
            sliderInfoIconHeating.cachedName = "sliderInfoIconHeating";
            sliderInfoIconHeating = AddUIComponent<UISlider>();
            sliderInfoIconHeating.size = new Vector2(150, 10);
            sliderInfoIconHeating.relativePosition = new Vector3(40, 125);
            sliderInfoIconHeating.BringToFront();
            sliderInfoIconHeating.backgroundSprite = "MeterBackground";
            sliderInfoIconHeating.minValue = 0f;
            sliderInfoIconHeating.maxValue = 1.9f;
            sliderInfoIconHeating.stepSize = 0.01f;
            sliderInfoIconHeating.value = 0f;
            sliderInfoIconHeating.thumbObject = AddUIComponent<UISprite>();
            (sliderInfoIconHeating.thumbObject as UISprite).spriteName = "MeterIndicator";
            sliderInfoIconHeating.thumbObject.name = "Thumb";

            labelImport = AddUIComponent<UILabel>();
            labelImport.width = 80;
            labelImport.height = 20;
            labelImport.textScale = 0.6f;
            labelImport.textAlignment = UIHorizontalAlignment.Left;
            labelImport.text = "Import: 0";
            labelImport.relativePosition = new Vector3 (40, 150);

            labelExport = AddUIComponent<UILabel>();
            labelExport.width = 80;
            labelExport.height = 20;
            labelExport.textScale = 0.6f;
            labelExport.textAlignment = UIHorizontalAlignment.Left;
            labelExport.text = "Export: 0";
            labelExport.relativePosition = new Vector3 (130, 150);
        }

        public override void Start()
        {
            Debug.Print("Creating Panel...");
            base.Start();

            this.autoLayout = true;
            this.autoLayoutStart = LayoutStart.TopLeft;
            this.autoLayoutDirection = LayoutDirection.Vertical;
            this.autoSize = true;
            this.canFocus = true;
            this.isInteractive = true;
            this.width = 220;
            this.height = 180;
            this.backgroundSprite = "MenuPanel2";

            title = AddUIComponent<UILabel>();
            title.width = 220;
            title.height = 20;
            title.textScale = 0.9f;
            title.textAlignment = UIHorizontalAlignment.Center;
            title.text = "District Stats";
            title.padding = new RectOffset(5, 5, 5, 5);
            title.relativePosition = Vector3.zero;
            this.autoLayout = false;

            CreatePanel();
            Hide();
        }

        /**
         * FROM District Service Limit:
         * It's a bit tricky to get the building selection right:
         * 1) When selecting another building without deselecting the previous one, the OnVisibilityChanged
         * is not invoked, but just the OnPositionChanged.
         * 2) Even when the OnVisibilityChanged is called, when retrieving the current building within the
         * event handler, the previous building (or zero, if none was selected) will be retrieved instead. 
         * -----
         * In the next frame the building will have the correct value, so I'm using MonoBehavior's Update()
         * method here to wait the next tick and then retrieve the building with confidence.
         */
        public override void Update()
        {
            base.Update();
            if (displayRequested)
            {
                updateCount++;
                if (updateCount > 0)
                {
                    updateCount = 0;
                    isShowing = true;

                    SetInfo(GetDistrict());
                    Show();
                }
            }
        }

        public void OnVisibilityChanged(UIComponent component, bool visible)
        {
            if (isShowing && !visible)
            {
                Hide();
                isShowing = false;
                displayRequested = false;
            }
        }


        private void SetInfo(District district)
        {

            // UISprite ToolbarIconElectricity
            int capElectricity = district.GetElectricityCapacity();
            int comElectricity = district.GetElectricityConsumption();
            sliderToolbarIconElectricity.value = capElectricity / Mathf.Max(comElectricity, 1);
            sliderToolbarIconElectricity.tooltip = $"Capacity: {capElectricity} Consumption: {comElectricity}";

            // UISprite ToolbarIconWaterAndSewage
            int capWater = district.GetWaterCapacity();
            int comWater = district.GetWaterConsumption();
            int capSewage = district.GetSewageCapacity();
            int comSewage = district.GetSewageAccumulation();
            sliderToolbarIconWaterAndSewage.value = (capWater) / Mathf.Max(comWater, 1);
            sliderToolbarIconWaterAndSewage.tooltip = $"Capacity: {capWater} Consumption: {comWater}";

            // UISprite ToolbarIconGarbage
            int capGarbage = district.GetGarbageCapacity();
            int capGarbageInc = district.GetIncinerationCapacity();
            int comGarbage = district.GetGarbageAccumulation();
            sliderToolbarIconGarbage.value = (capGarbage + capGarbageInc) / Mathf.Max(comGarbage, 1);
            sliderToolbarIconGarbage.tooltip = $"Capacity: {capGarbage+capGarbageInc} Accumulation: {comGarbage}";

            // UISprite InfoIconHeating
            int capHeat = district.GetHeatingCapacity();
            int comHeat = district.GetHeatingConsumption();
            sliderInfoIconHeating.value = capHeat / Mathf.Max(comHeat, 1);
            sliderInfoIconHeating.tooltip = $"Capacity: {capHeat} Consumption: {comHeat}";

            // UISprite InfoIconOutsideConnectionPressed    
            uint amtExport = district.m_exportData.m_averageAgricultural + district.m_exportData.m_averageForestry + district.m_exportData.m_averageGoods + district.m_exportData.m_averageOil + district.m_exportData.m_averageOre;
            uint amtImport = district.m_importData.m_averageAgricultural + district.m_importData.m_averageForestry + district.m_importData.m_averageGoods + district.m_importData.m_averageOil + district.m_importData.m_averageOre;
            labelImport.text = "Import: " + amtImport;
            labelExport.text = "Export: " + amtExport;
        }       

        //private District GetDistrict(string name){
        private District GetDistrict()
        {
            Debug.Print("District active: " + ToolsModifierControl.policiesPanel.targetDistrict + " - " + Singleton<DistrictManager>.instance.GetDistrictName(ToolsModifierControl.policiesPanel.targetDistrict));
            if (ToolsModifierControl.policiesPanel.targetDistrict != 0)
                return Singleton<DistrictManager>.instance.m_districts.m_buffer[ToolsModifierControl.policiesPanel.targetDistrict];
            else
                return new District { m_flags = District.Flags.None };
        }
    }


	public class DistrictStatsHook : ILoadingExtension {

		public static UIPanel m_UIPanel;
        public static DistrictWorldInfoPanel m_DistrictWIP;
        public DistrictStatsPanel statsPanel;
        public static GameObject statsGO;
        public static UISprite iconDistrictStats;


        public void OnCreated(ILoading loading)
        { }

		public void OnLevelLoaded(LoadMode mode){
			if (!(mode == LoadMode.LoadGame || mode == LoadMode.NewGame)) {
				return;
			}
			Debug.Print ("OnLevelLoaded()");
			DestroyOld ("DistrictStats");

			var timer = new Timer (11000); //delays GUI hook so other mods such as Building Themes can do its thing
			timer.Elapsed += (object sender, ElapsedEventArgs e) => {
                HookGUI();
                timer.Enabled = false;
                timer.Dispose();
            };

			timer.Enabled = true;
		}

		private void DestroyOld(string name)
        {
            GameObject.DestroyImmediate(iconDistrictStats);
            GameObject.DestroyImmediate(statsPanel);
            GameObject.DestroyImmediate(statsGO);
        }

        public class DistrictStatsException : Exception
        {
            public DistrictStatsException(string msg) : base(msg) { }
        }

		private void HookGUI(){
			Debug.Print("Hooking GUI");

            m_DistrictWIP = UIView.library.Get<DistrictWorldInfoPanel>(typeof(DistrictWorldInfoPanel).Name);
            m_UIPanel = UIView.library.Get<UIPanel>(typeof(DistrictWorldInfoPanel).Name);

            statsGO = new GameObject("DistrictStats");
            statsPanel = statsGO.AddComponent<DistrictStatsPanel>();
            statsPanel.transform.parent = m_UIPanel.transform;
            statsPanel.relativePosition = new Vector3(m_UIPanel.width + 5, m_UIPanel.height - 220);

            // icon
            iconDistrictStats = m_UIPanel.AddUIComponent<UISprite>();

            if (m_DistrictWIP == null || m_UIPanel == null || statsPanel == null || iconDistrictStats == null)
            {
                throw new DistrictStatsException("DistrictStats couldn't hook GUI");
            }

            // setup icon
            iconDistrictStats.spriteName = "ToolbarIconElectricity";
            iconDistrictStats.name = "Icon";
            iconDistrictStats.tooltip = "DistrictStats - show capacity & consumption";
            iconDistrictStats.size = new Vector2(40, 40);
            iconDistrictStats.relativePosition = new Vector3(m_UIPanel.width - DistrictStatsHook.iconDistrictStats.width - 5, m_UIPanel.height - DistrictStatsHook.iconDistrictStats.height - 125);
            iconDistrictStats.Show();
            iconDistrictStats.BringToFront();

            // custom panel only for triggering
            iconDistrictStats.eventClicked += (component, value) => { statsPanel.displayRequested = true; };
            m_UIPanel.eventVisibilityChanged += (component, value) => { statsPanel.OnVisibilityChanged(component, value); };

            Debug.Print("Hooking GUI completed.");
        }
        
		public void OnReleased()
        {
            Debug.Print("Released");
            try
            {
                if (m_UIPanel != null && iconDistrictStats != null)
                    m_UIPanel.RemoveUIComponent(iconDistrictStats);

                DestroyOld("DistrictStats");
            }
            catch
            { }
        }

		public void OnLevelUnloading()
        {
            OnReleased();
        }

	}
}

