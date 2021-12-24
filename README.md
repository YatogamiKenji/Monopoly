# Project Lập Trình Trực Quan
<a name="top"><a>
## Mục lục

[Thông tin nhóm](#info)\
[Đề tài](#topic)\
[Mô tả project](#project)\
&nbsp;&nbsp;&nbsp; [Công nghệ sử dụng](#use)\
&nbsp;&nbsp;&nbsp; [Tính năng chính](#main-feature)\
[Demo](#demo)

## Thông tin nhóm <a name="info"></a>

Lớp: **IT008.M11** \
Mã nhóm: **15** \
Thành viên:
| STT  | Tên                | MSSV      | Ghi chú     |
|:-----|:-------------------|:----------|:------------|
|  1   |  Vũ Xuân Hoàng Lâm | 20520609  |  Trưởng nhóm|
|  2   |  Trần Ngọc Tiến    |  20520808 |             |
|  3   | Bùi Tống Minh Châu | 20521123  |             |
|  4   |  Trần Trọng Hoàng  |  20520521 |             |
|  5   | Huỳnh Tuấn Anh     | 20520383  |             |

[Lên đầu trang](#top)
## Đề tài <a name="topic"></a>

Xây dựng game cờ tỷ phú trên wpf bằng ngôn ngữ c#

## Mô tả Project <a name="project"></a>

### Công nghệ sử dụng <a name="use"></a>

- Ngôn ngữ: C#
- Famework: WPF 

[Lên đầu trang](#top)
### Tính năng chính <a name="main-feature"></a>
  #### Cơ chế:
  - Offline, nhiều người chơi trên 1 máy
  - Điều kiện chiến thắng
    - Chế độ giới hạn: Sau một số lượt nhất định không ai phá sản, người nhiều tiền nhất chiến thắng
    - Chế độ thông thường: Các người chơi đều phá sản hết và còn duy nhất một người chơi trên bàn cờ
  - Đi qua ô bắt đầu: 1000 * số lần qua ô bắt đầu, max 10000

  #### Tính năng:
  - Mua hành tinh, xây nhà (4 căn, 1 khách sạn)
  - Bán đất cho ngân hàng
  - Thẻ cơ hội
    - Đến ô chỉ định: đất cao cấp, trung bình, đắt, ô bắt đầu
        - Đến Cổng Dịch Chuyển (Gặp WormHole //bạn sẽ được đến cổng)
        - Dịch chuyển đến Valoran (Gặp WormHole dịch chuyển đến Valoran)
        - Dịch chuyển đến Devil (Gặp WormHole dịch chuyển đến Devil)
        - Dịch chuyển đến Asgard (Gặp Cổng dịch chuyển mini dịch chuyển đến Asgard)
    - Trừ x tiền (cao, trung bình, thấp)
        - Va phải rác vũ trụ che tầm nhìn (Chất thải rắn của tàu khác) -500
        - Bay quá tốc độ bị cảnh sát vũ trụ bắt -1500
        - Bị tấn công (Gặp phải dân Istanlao tấn công sửa chữa tàu) -2500
    - Bản đồ bị lỗi (Đi lùi 4 bước)
    - Lãnh x tiền (cao, trung bình, thấp)
        - Gặp khoáng sản quý hiếm +3000
        - Nhặt được kho báu +2000
        - Cứu tàu bị nạn thưởng +1000
    - Ra tù (có thể bán)
    - Vào tù
  - Thẻ khí vận
    - Vào tù
    - Lãnh x tiền (cao, trung bình, thấp)
        - Thắng giải đua tàu vũ trụ +2000
        - Nhà Bank liên vũ trụ lỗi tiền +3000
        - Làm công việc ngoài giờ tại các hành tinh +1000
    - Trừ x tiền (cao, trung bình, thấp)
        - Gặp Space Pirate -1500
        - Nâng cấp tàu -2500
        - Sạc nhiên liệu -500
    - Đến Cổng Dịch Chuyển (Gặp WormHole //bạn sẽ được đến cổng)
    - Tiến 3 bước (Không kiểm soát tốc độ)
    - Trừ tiền tập thể + cho 1 người (Tổ chức đám cưới mỗi người -500 + theo số người cho người cưới)
    - 1 người + tiền cho mọi người (Hối lộ lên chức trả mỗi người 500  + theo số người người hối lộ)
    - Trừ tiền thuế dựa trên hành tinh (số hành tinh * 200)
- Thẻ quyền năng: trả tiền bằng giá trị*số xúc xắc
    - buff cho bản thân
        - Loại thường (5): 500 → 1000
            - Loại bỏ lần mất tiền tiếp theo. Giá trị: 700
            - Dịch chuyển đến một ô trong phạm vi xúc sắc đổ được. Giá trị: 900 .
            - Không vào tù trong 10 lượt. Giá trị: 600 .
            - Tăng 2 bất giá trị qua ô bắt đầu. Giá trị: 500 .
            - Nhân đôi xúc xắc trong 7 lượt. Giá trị: 900 .
        - Hiếm (3): 1000 → 2000
            - Dịch chuyển đến một ô bất kì. Giá trị: 1000 .
            - Tăng giá trị thuê đất +100%. Giá trị: 1500 .
            - Giảm tiền nâng cấp -50% (chọn 1 khu đất). Giá trị: 1800 .
        - Huyền thoại (2): 2000 → 3000
            - Trong 2 vòng không dính hiệu ứng bất lợi. Giá trị: 2500 .
            - Tăng vĩnh viễn giá trị đất +100%. Giá trị: 3000 .
    - Phá người khác
        - Loại thường (5): 500 → 1000
            - Chia đôi xúc xắc của người khác 7 lượt. Giá trị: 500 .
            - Giảm 50% giá trị đất trong 2 lượt. Giá trị: 700 .
            - Khoá một ô đất trong 2 lượt. Giá trị: 500 .
            - Bắt 1 người đến ô thuế. Giá trị: 700 .
            - Đóng băng tài khoản ngân hàng trong 2 lượt. Giá trị: 1000 .
        - Hiếm (3): 1000 → 2000
            - Cho 1 người vào tù. Giá trị: 1000 .
            - Huỷ bỏ 1 thẻ quyền năng của 1 người khác. Giá trị: 2000 .
            - Cầm chân 1 người trong 5 lượt. Giá trị: 1500 .
        - Huyền thoại (2): 2000 → 3000
            - Ăn cắp đất người khác. Giá trị: 3000 .
            - Giảm 2 lv đất của 1 người. Giá trị: 2500 .
  
### Cấu trúc
  - Map:
    - Chủ đề: Khoa học vũ trụ
    - Có 40 ô:
        - Ô bắt đầu: 1
        - Ô đỗ xe: 1
        - Ô nhà tù: 1
        - Ô vào tù: 1
        - Ô quyền năng: 2 (Thẻ quyền năng)
            - Nhận thẻ khi bắt đầu
            - Nhận thẻ khi đi qua ô "quyền năng"
            - Giới hạn số thẻ: 5 thẻ
        - Ô khí vận: 2
        - Ô cơ hội: 2
        - Ô đất (chung)
            - Nâng cấp (% giá mua)
                - lv1: 40%
                - lv2: 60%
                - lv3: 80%
                - lv4: 100%
                - lv5: 200%
            - Thuế (trả khi đi vào đất người khác): 1 ≤ lv ≤ 3: 10%*giá trị đất, lv ≥ 4: 20%*giá trị đất
        - Ô đất rẻ :
            - Mua: 1000 → 4000
        - Ô đất trung bình :
            - Mua: 4000 → 8000
        - Ô đất đắt:
            - Mua: 8000 → 12000
        - Ô đất cao cấp:
            - Mua: 12000 → 15000
            - Thuế (trả khi đi vào đất người khác):
        - Ô thuế: 2
            - 10% giá trị tiền đang có
  - Tài nguyên
    - Bắt đầu game: 10000
    - Thẻ quyền năng: random 1 thẻ
  - Số lượng người chơi: 2 -> 4

## Demo <a name="demo"></a>
[Lên đầu trang](#top)
