using MvvmCross.Platforms.Ios.Binding.Views;

namespace iOSMvvmCross.Views.Cells;

public class NameTableViewCell : MvxStandardTableViewCell
{
    public static NSString Identifier = new NSString("NameTableViewCell");
    public const string BindingText = "TitleText Title";

    public NameTableViewCell(IntPtr handle) : base(BindingText, handle)
    {
        CreateView();
    }


    public NameTableViewCell()
        : base(BindingText, UITableViewCellStyle.Default, Identifier)
    {
    }

    public NameTableViewCell(string bindingText)
        : base(bindingText, UITableViewCellStyle.Default, Identifier)
    {
    }

    void CreateView()
    {
        SelectionStyle = UITableViewCellSelectionStyle.None;

        BackgroundColor = UIColor.Clear;
    }

    public string MainText
    {
        get {
            return TitleText;
        }
        set {
            TitleText = value;
        }
    }

}

