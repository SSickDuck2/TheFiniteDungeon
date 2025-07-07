this is a shit show, sorry

hướng dẫn tương tác có sẵn ở trong game rồi :(( (lie)
di chuyển A và D để sang trái phải
Space để nhảy
J để tấn công

Tính năng đã hoàn thành

1. Cơ bản & Cấu trúc mã (chưa chắc)
- Sử dụng OOP chuẩn: phân chia class rõ ràng (PlayerController, EnemyController, GameManager…)
- Áp dụng SOLID và Clean code.
- Viết mã tách biệt logic điều khiển, UI, xử lý vật lý.

2. Nhân vật chính
- Nhân vật điều khiển được (di chuyển trái/phải, nhảy hoặc bắn đạn).
- Điều khiển bằng script riêng (PlayerController.cs).
- Coyote Time :D

3. Object và Tương tác
- Có Enemy hoặc chướng ngại vật hoạt động.
- Có Item (vật phẩm) thu thập được. (Chưa)
- Sử dụng Raycast hoặc Collider để phát hiện va chạm.

4. Prefab & Object Pooling
- Biến Item hoặc Enemy thành prefab.
- Áp dụng Object Pooling để spawn object. (Chưa)

5. Animation & State Machine
- Animation cho nhân vật (Idle, Run, Jump...)
- Dùng Animator và State Pattern để điều khiển.

6. ScriptableObject & Singleton
- Tạo ScriptableObject chứa config dữ liệu. (chưa có)
- Dùng Singleton cho GameManager, AudioManager hoặc UIManager.

7. UI & Scene
- UI hiển thị điểm số, máu, nút restart. (chưa có)
- Dùng SceneManager để chuyển giữa các màn hình.
- Events UI (nút bấm, sự kiện tương tác).

8. Âm thanh & Tween
- Âm thanh cho các hành động chính.
- Sử dụng Tween (như DOTween) để làm hiệu ứng động.

9. Tilemap
