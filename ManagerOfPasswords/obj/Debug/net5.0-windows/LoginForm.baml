   M S B A M L   `   `   `  ����M  IManagerOfPasswords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ManagerOfPasswordsManagerOfPasswords  5   	   "    ManagerOfPasswords.LoginForm   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local clr-namespace:ManagerOfPasswords  5   	   ���#262626  � Title$6  0Войдите в учетную запись...��5
   	   $	��300��6-   $	��300��6=   $	��400��6L   $	��400��6X   $	��600��6e   $	��600��6u   $��Roboto)�5   	    � 	Resources 5         
LoginField �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value.  (MaterialDesignThemes.Wpf.TextFieldAssist)  #MaterialDesignThemes.Wpf.HintAssist  	PassField ) %MaterialDesignFloatingHintPasswordBox  Buttons  MaterialDesignFlatButton+  %MaterialDesignThemes.Wpf.ButtonAssist��%  &	        7  &	 �    7  &	 P    7  �� 5   
   " ��6#   8   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5 0 0 0q�6(   �� 5       � ��$ 
15 15 15 0q�6'   �� 5       � �� �#BFBFBF6+   �� 5       � �� �#BFBFBF6,   �� 5       �@ UnderlineBrush �#BFBFBF6N   �� 5       �@ 
Foreground �#BFBFBF6E   �� 5       �@ Hint$" Введите логин...��6?   5      �� 5   
   " G�6"   8   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5 0 0 0q�6(   �� 5       � ��$ 
15 15 15 0q�6'   �� 5       � �� �#BFBFBF6+   �� 5       � �� �#BFBFBF6,   �� 5       �@ Hint$$ Введите пароль...��6?   �� 5       �@ UnderlineBrush �#BFBFBF6N   �� 5       �@ 
Foreground �#BFBFBF6E   5       �� 5!   
   " ��6    8   .�5"      ��  � ��$ 0q�6(   �� 5#       � ��$	 100��6&   �� 5$       � ��$ 25��6'   �� 5%       � ��$ Center=�64   �� 5&       � �� �#473D3D6+   �� 5'       � �� �#BFBFBF6+   �� 5(       �@ CornerRadius$ 10��6I   �� 5)       �@�Cursor$
 Hand��6'   �� 5*       � ��$ 12(�6)   5+      5-      .��5.      �  � RowDefinitions 5/   
   �� 50      $��1* �6   �� 51      $��5* �6    � ColumnDefinitions 53   
   �� 54      $��1* �6   �� 55      $��9* �6   .+�57   
   �� -   5         ��Name$ BackStep��57      #��[ 6#   
������ 
������ $��20��6�   $��20��6�   $��0q�58      $y�	Collapsed=�6   .��59      �� $@��:D:\proj\passwords_manager\ManagerOfPasswords\Icons\pen.png��6   $��20��6X   $��20��6d   5:      �� 5;   
   -   5        	 ��Name$	 HeadText��5;      $��Вход��6"   $��Center=�61   $��Center=�6N   $��Black"�6i   ���#BFBFBF$��2��6�   �� 5<   
   $��1��6   $��2��6"   .+�5=      �� -   5        
 ��Name$
 
loginField��5=      #��[  6*   $
|�True��6O    � Cursor$ IBeam��6`   6o   G� 5>      -   5         G�Name$ 	passField��5>      #��[ 6-   6P   G� 5?      -   5        $ 
repeatPass��5?      #��[ 6.      Hint$( "Повторите пароль...��6R   $y�	Collapsed=�5@      � 5A      $��0 20 0 0q�6    5B      �� 5C      �� 5D      .+�5F      �� -   5        $ Entry��5F      $��
Войти��6(   #��[ 68   $
 Hand��6m   �� 5G      -   5        $ Register��5G      $��Регистрация��6+   #��[ 6A   ���#BFBFBF���#473D3D$��1��6�   6�   5H      �� 5I      -   5         ��Name$ WarningMessages��5I      $��15q�62   $y�Hidden=�6>   .+�5J      �� $@��:D:\proj\passwords_manager\ManagerOfPasswords\Icons\pen.png��6   $��14��6\   $��14��6g   $��0 0 0 10q�6s   �� 5K      $n��hНе удалось войти, проверьте правильность логина и пароля��6   $��Center=�6\   ���#914C4C$��DemiBold"�6�   $
��Wrap=�6�   5L      5N      5O      5P      