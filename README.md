Game lấy ý tưởng từ vòng farm quái của game quỷ cốc bát hoang

Nhân vật sẽ có 4 kỹ năng: Đánh thường (Chuột trái) , chiêu cơ bản (Chuột phải) , chiêu hỗ trợ di chuyển (Space) và ultimate (R)

Ngoài ra nhân vật sẽ có hệ thống kho đồ gồm 5 ô khi vào trận và nhân vật có thể sử dụng thông qua các phím từ 1-5

Game có sử dụng một vài design pattern cơ bản: Singleton, State Pattern, Strategy Pattern, Observer Pattern.
Trong đó:
+ Singleton sử dụng trong 1 vài tính năng tồn tại xuyên suốt như GameManager
+ State Pattern: Sử dụng trong việc quản lý trạng thái Enemy (Chase, Attack ,...) và trạng thái của Game (Lose, Win, Pause ,...)
+ Strategy Pattern: Xây dựng hệ thống chiêu thức gồm 4 chiêu kể trên và các chiêu thức của Enemy
+ Observer Pattern: Cập nhật trạng thái UI chẳng hạn như kho đồ (Khi nhặt Item) hoặc trạng thái thanh máu của Player và Enemy
Ngoài ra việc xuất ra skill và enemy sử dụng Pooling Object
