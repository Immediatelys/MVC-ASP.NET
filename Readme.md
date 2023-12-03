##View

- LÀ file .cshtml
- View cho các Action lưu tại : /View/ControllrName/ActionName.cshtml
- them thư mục lưu trữ cho view
  ##Controler
- Kề thừa từ lớp Controller
- Các action là public ko đc static
- các dịch vụ inject qua hàm tạo

// {0} -> ten Action
// {1} -> ten controller
// {2} -> ten Area

option.ViewLoactionFormat.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension)
