   M S B A M L   `   `   `  ����M  IManagerOfPasswords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ManagerOfPasswordsManagerOfPasswords  5   	   #    ManagerOfPasswords.AddAccount   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ManagerOfPasswords     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$+  %Добавление аккаунта��5	   	   $	��300��6%   $	��300��65   $	��450��6D   $	��400��6Q   $	��600��6]   $	��600��6m   ���#262626 � 	Resources 5         	TextField �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value.  (MaterialDesignThemes.Wpf.TextFieldAssist)  #MaterialDesignThemes.Wpf.HintAssist  	PassField ) %MaterialDesignFloatingHintPasswordBox  Buttons  MaterialDesignFlatButton+  %MaterialDesignThemes.Wpf.ButtonAssist��%�  &	        7  &	 d    7  &	     7  �� 5   
   " ��6"   8   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5 0 0 0q�6(   �� 5       � ��$ 
15 15 15 0q�6'   �� 5       � �� �#BFBFBF6+   �� 5       � �� �#BFBFBF6,   �� 5       �@ UnderlineBrush �#BFBFBF6N   �� 5       �@ 
Foreground �#BFBFBF6E   5      �� 5   
   " G�6"   8   .�5      ��  � ��$ 12(�6)   �� 5       � ��$ 5 0 0 0q�6(   �� 5       � ��$ 
15 15 15 0q�6'   �� 5       � �� �#BFBFBF6+   �� 5       � �� �#BFBFBF6,   �� 5       �@ Hint$$ Введите пароль...��6?   �� 5       �@ UnderlineBrush �#BFBFBF6N   �� 5       �@ 
Foreground �#BFBFBF6E   5      �� 5   
   " ��6    8   .�5       ��  � ��$ 0q�6(   �� 5!       � ��$	 100��6&   �� 5"       � ��$ 25��6'   �� 5#       � ��$ 0 15 0 0q�6'   �� 5$       � ��$ Center=�64   �� 5%       � �� �#473D3D6+   �� 5&       � �� �#BFBFBF6+   �� 5'       �@ CornerRadius$ 10��6I   �� 5(       �@�Cursor$
 Hand��6'   �� 5)       � ��$ 12(�6)   5*      5,      .��5-      �  � RowDefinitions 5.   
   �� 5/      $��1* �6   �� 50      $��5* �6    � ColumnDefinitions 52   
   �� 53      $��1* �6   �� 54      $��9* �6   .+�56   
   �� -   5         ��Name$ backstep��56      #��[ 6#   
������ 
������ $��20��6�   $��20��6�   $��0q�57      .��58      �� $@��:D:\proj\passwords_manager\ManagerOfPasswords\Icons\pen.png��6   $��20��6X   $��20��6d   59      �� 5;   
   $%��Добавить аккаунт��6   $��Center=�6+   $��Center=�6H   $��Black"�6c   ���#BFBFBF$��2��6�   �� 5=   
   -   5        	 ��Name$	 Fields��5=   6   $��1��6   $��2��6"   .+�5>      �� -   5        
 ��Name$
 add_address��5>      #��[  6+   $
|�True��6N    � Cursor$ IBeam��6_      Hint$4 .Введите адрес веб-сайта...��6n   6�   �� 5?      -   5        $
 add_name��5?      #��[  6(   $
|�True��6K   $ IBeam��6\   $7 1Введите имя пользователя...��6k   6�   G� 5@      -   5         G�Name$ add_pass��5@      #��[ 6,   6O   G� 5A      -   5        $ 
add_repeat��5A      #��[ 6.   $( "Повторите пароль...��6Q   6�   �� 5C      $��0 10 0 0q�6   .+�5D      �� -   5        $	 add��5D      $��Добавить��6&   #��[ 69   $
 Hand��6Z   �� 5F      -	   5        $	 WarningMessages��5F   /   $��0 10 0 0q�6   $y�	Collapsed=�6H   .+�5G      �� $@��:D:\proj\passwords_manager\ManagerOfPasswords\Icons\pen.png��6   $��14��6`   $��14��6k   $��	0 15 0 10q�6w   �� 5H      -
   5         ��Name$ message��5H       $��Center=�62   ���#914C4C$��DemiBold"�6d   $
��Wrap=�6z   �� 5I      -   5        $ refresh��5I      $��Обновить��6.   #��[ 6A   ���#BFBFBF���#473D3D$��1��6�   5J      5L      5M      5N      5O      