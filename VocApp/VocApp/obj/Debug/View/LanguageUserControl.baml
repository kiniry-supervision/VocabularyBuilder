   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      
 VocApp%   VocApp.View.LanguageUserControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5	         	flagwidth��%%   &	        X�5
   
   100Q�6-   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��20(�61   $
��Bold"�6?   $��Center=�6Q   $��Your language: ��6l   �� 5   
   $��0��6   $��1��6     �� Text$	 Hey��60    �� SelectedIndex$ 0��6;    �� SelectedItem 6M   �� *YourLanguage+ �� Mode$ OneWayToSource=�.@�5      �� 
 � Tag$ en��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Icons/english_flag.png��6   #��[  6<   �� 5      $��30(�6    $��English��6.   $��Center=�6=   5      5      �� 5      $ da��6   .��5      �� $ 
Horizontal=�6   .+�5       �� $��Icons/danish_flag.png��6   #��[  6;   �� 5!      $��30(�6    $��Danish��6.   $��Center=�6<   5"      5#      �� 5$      $ de��6   .��5%      �� $ 
Horizontal=�6   .+�5&      �� $��Icons/german_flag.png��6   #��[  6;   �� 5'      $��30(�6    $��German��6.   $��Center=�6<   5(      5)      5*      �� 5+   
   $��1��6   $��2��6!   $	��0,5q�65   �� 5,   
   $��2��6   $��0��6!   $��20(�61   $
��Bold"�6?   $��Center=�6Q   $��Target language: ��6l   �� 5-   
   $��2��6   $��1��6    $	 Hey��60   $ 1��6;    6M   �� *TargetLanguage+$ OneWayToSource=�.@�5.      �� $ en��6   .��5/      �� $ 
Horizontal=�6   .+�50      �� $��Icons/english_flag.png��6   #��[  6<   �� 51      $��30(�6    $��English��6.   $��Center=�6=   52      53      �� 54      $ da��6   .��55      �� $ 
Horizontal=�6   .+�56      �� $��Icons/danish_flag.png��6   #��[  6;   �� 57      $��30(�6    $��Danish��6.   $��Center=�6<   58      59      �� 5:      $ de��6   .��5;      �� $ 
Horizontal=�6   .+�5<      �� $��Icons/german_flag.png��6   #��[  6;   �� 5=      $��30(�6    $��German��6.   $��Center=�6<   5>      5?      5@      5A      5B      