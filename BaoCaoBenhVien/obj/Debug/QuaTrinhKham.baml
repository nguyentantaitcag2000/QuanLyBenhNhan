   M S B A M L   `   `   `  ����I  EBaoCaoBenhVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BaoCaoBenhVienBaoCaoBenhVien  5   	   !    BaoCaoBenhVien.QuaTrinhKham   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BaoCaoBenhVien     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
   -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        QTVM � DataContext# [ 5       � WindowStartupLocation$ CenterScreen=�5   	    � Cursor$	 Pen��5   	    � Title$ Quá trình khám��5   	   $	��600��6    $
��1000��6-   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadedWindow_Command+
   CommandParameter
 6M   ��  �� ElementName$ 
mainWinDow��6�   5        5   
   $ Closed��6   . 5        	 6$   �� *ClosedWindow_Command+
 6M   �� $ 
mainWinDow��6�   5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      $	��67* �6   �� 5#      $	��32* �6    � RowDefinitions 5%   
   �� 5&      $
��0.8* �6   6,   �� 5'      $��1* �6   6*   �� 5(      $
��0.4* �6   6,   .+�5*   
   � $��0��6   $��30 0 0 0q�6   $��2��6.    5+      �� 5,      6"   �� 5-      6"   �� 5.      $
��1.5* �6    60   .+�50      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�51      �� $ 
Horizontal=�6   .+�52      (  "System.Windows.Controls.DatePicker  -   5          Name$ Text_Ngaykham��55      $	��260��53      $��15(�54      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$( "Ngày khám (Date of examination)*��56       ( $MaterialDesignFloatingHintDatePicker#��[ 57      58      �� 59      $ 
Horizontal=�6   .+�5:        -   5        $ Text_Ngayhen��5<      $	��240��5;      $��15(�5=      $��50 0 0 0q�5@      $% Ngày hẹn (Appointment date)*��5A      #��[ 5B      5C      5E      �� 5F      $��1��6   $ 
Horizontal=�6&    � 	Resources 5G       �� 
TargetType �� Property �� Value��%T   '��       �� 5H      " ��6   .�5I      ��  � ��$
 Bold"�68   5J      5K      .+�5L      �� $	��160��6    �� Padding$ 	0 10 10 0q�6)   $��15(�6=   $��Center=�6K   Nội dung hẹn (Details):6�   �� 5N      -   5         ��Name$ Text_Noidunghen��5U      $��2��5O      $	��200��5P      $��0 10 0 0q�5Q      $��15(�5R       �� 
IsEditable . $	��Top=�5T      .@�5V      �� .��6#   (&Chụp HSG (Sau sạch kinh 2-3 ngày)6F   �� 5W      .��6#   SQKích thích buồng trứng (XN nội tiết, Siêu âm đầu dò âm đạọ)6`   �� 5X      .��6#   YWChọc hút noãn (Vợ nhịn ăn sáng, Chồng lấy tinh trùng, Có mặt lúc 7h)6i   �� 5Y      .��6#   
Báo phôi6-   �� 5Z      .��6#   64Chuyển phôi (Hẹn có mặt 7g30 chuyển phôi)6N   �� 5[      .��6#   $"Thử beta HCG (8g thử beta HCG)6C   �� 5\      .��6#   Siêu âm thai61   �� 5]      .��6#   vtTinh dịch đồ kiểm sau 1 tháng. Lưu ý: kiêng quan hệ 3-5 ngày trước khi kiểm tra tinh dịch đồ6�   5^      5_      �� 5`      $��2��6   $
��Left=�6&   $��Center=�6A   $ 
Horizontal=�6\   .+�5a      �� -   5        $ TEXT_Huongdieutri��5g      $��2��5b      $	��200��5c      $��15(�5d      $) #Hướng điều chị (Treatment)*��5e       .    HintOpacity$	 .26Q�5h      .@�5i      �� .��6#   IUI6(   �� 5j      .��6#   IVF6(   �� 5k      .��6#   IVF- Xin tinh trùng68   �� 5l      .��6#   IVF - Xin noãn63   �� 5m      .��6#   	PESA/TESE6.   �� 5n      .��6#   Sinh Thiết Tinh Hoàn69   5o      �� 5p      -   5        $ TEXT_BacSiKham��5w      $��2��5q      $	��250��5r      $��15(�5s      $��	100 0 0 0q�5t      $, &Bác sĩ tư vấn (Consulting Doctor)��5u       . $	 .26Q�5x      .@�5y      �� .��6#   Ths.BS. Nguyễn Phan Vinh6=   �� 5z      .��6#   BS.CKI. Trần Ngọc Thảo6;   �� 5{      .��6#   BS.CKI. Nguyễn Phúc Tùng6=   �� 5|      .��6#   " BS.NT. Nguyễn Thị Thanh Dung6A   �� 5}      .��6#    BS. Nguyễn Thị Thanh Ngân6>   �� 5~      .��6#   BS. Nguyễn Thành Phước6;   �� 5      .��6#   BS. Nguyễn Hoàng Thành6;   �� 5�      .��6#   BS. Trần Ngọc Long67   5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ DataGrid_Main��5�      $��1��5�       �� SelectedIndex$ 0��5�         CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     
IsReadOnly . ���#F5F6F6
���   �   	RowHeight$ 40Q�5�      $��Stretch=�5�      $
��auto��5�      $
��auto��5�      $��Stretch=�5�      $��2��64     �� SelectedItem  5�      �� *SelectedItem+! �� Mode$! TwoWay=���5�      �� *InfoAccounts+ 5�      ��%T   '��       �� 5�      " ��6   .�5�      ��  � ��
 �   �63   5�      5�      "   Columns" 5�      0	  *System.Windows.Controls.DataGridTextColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn# 
  Header$'# !Ngày khám
(Date of examination)��6%   $ 
  MinWidth$$ 50Q�6o   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 6R   �� *
Ngaykham+6o   	  5�      $$# Ngày hẹn
(Appointment date)��6%   $$ 50Q�6j   % 6N   �� *	Ngayhen+6j   	  5�      $ # Nội dung hẹn
(Details)��6%   $$ 50Q�6h   % 6I   �� *
Noidunghen+6h   	  5�      $(# "Hướng điều trị
(Treatment)��6%   $$ 50Q�6n   % 6M   �� *Huongdieutri+6n   	  5�      $,# &Bác sĩ tư vấn
(Consulting Doctor)��6%   $$ 50Q�6o   % 6T   �� *Doctor+6o   5�      �� 5�   
   $��239,20,239,0q�6   $ 
Horizontal=�6+   $��Center=�6D   $��2��6a   $��2��6n   .+�5�      �� 
��� � �$��10q�6(   ��64   �� *Add_Command+.��6T   Thêm6Z   �� 5�      
���  ��$��10q�6'   ��63   �� *Delete_Command+.��6V   Xoá6[   �� 5�      $��10q�6   ��6!   �� *Edit_Command+.��6B   Sửa6G   �� 5�      
����+��$��0 0 10 0q�6-   ��6?   �� *Clear_Command+.��6a   Clear6h   5�      5�      5�      