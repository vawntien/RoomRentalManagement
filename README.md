# RoomRentalManagemen

#trước khi chạy(quan trọng):
    - tải framework ui2: Tool=>nuget package manager => package manager console=> install-package guna.ui2.winforms

    -máy phải có sẵn crystal. (link tải: https://www.aspsnippets.com/Articles/3962/Download-Crystal-Reports-for-Visual-Studio-2022/ )
     
    -chạy ứng dụng: Sửa datasource trong connecstring ở webconfig và class ConnectionModel thành sql server local
 
    -chạy web API để gọi ra mô hình ML gợi ý giá thuê hợp lý cho chủ nhà:
        Test API, Model: api.py => terminal => uvicorn api:app --reload' => running on http://127.0.0.1:8000/docs

  
#hướng dẫn sử dụng app
Run chương trình -> đăng nhập tài khoản admin default tài khoản: 'tien', mật khẩu :'123'.
Trong ứng dụng bao gồm: 
    + Overview: chứa thông tin chung (tạm thời để dạng table tĩnh).
    + Room management:  Chứa thông tin về toàn bộ các phòng trong cơ sở dữ liệu (Thêm, xóa, sửa, gợi ý phòng).
    + Tenant management: Chứa toàn bộ thông tin khách hàng đang thuê tại các phòng(Kiểm tra và cập nhật thông tin khách hàng).
    + Contact management: Chứa toàn bộ thông tin của hợp đồng thuê nhà(Chọn xem chi tiết để show ra toàn bộ danh sách hợp đồng đang thuê).

#Sử dụng mô hình ML với thuật toán hồi quy tuyến tính để đưa ra gợi ý giá thuê có phù hợp hay không:
    -Nhập đầy đủ thông tin khi thêm nhà và bấm gợi ý giá thuê (chắc chắn rằng đang chạy web API như hướng dẫn ở trên) sẽ đưa ra giá thuê hợp lý dựa trên tập dữ liệu giá thuê nhà thực tế.




