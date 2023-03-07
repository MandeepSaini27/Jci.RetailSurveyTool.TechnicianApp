using Jci.RetailSurveyTool.TechnicianApp.Models;

namespace Jci.RetailSurveyTool.TechnicianApp.Views.MasterPages;

public partial class MainFlyoutPage : FlyoutPage
{
	public MainFlyoutPage()
	{
		InitializeComponent();
        flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;
        }
    }
}
