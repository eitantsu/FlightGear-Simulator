   M S B A M L   `   `   `  ����M  IFlightSimulatorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FlightSimulatorAppFlightSimulatorApp  5   	   C&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5   	   #    FlightSimulatorApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FlightSimulatorApp     5   	   8Views&clr-namespace:FlightSimulatorApp.Views     5   	   -   5          � Title$  
MainWindow��5	   	   $	��500��6   $
��1200��6)    � WindowState$ Normal=�66   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��600 �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6   .+�5   
   )   #FlightSimulatorApp.Views.DashboardV  $��1��6   $��2��6(   $	��250��68   6F   ,   &FlightSimulatorApp.Views.JoystickAdded  5   
   $��1��6   $��1��6.   $��Center=�6;   �� 5   
   $��Center=�6   
���  ��$
��Bold"�6>   $��22(�6P   $��1��6^   $��Flight Simulator Project��6n   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ 	#FF2B2BBF��6#    � Offset$	 0.3Q�65   � 5      $ 	#FF28C9E2��6#   $	 0.7Q�65   � 5      $ 	#FF4F9F8C��6#   $ 1Q�65   5      5      '   !FlightSimulatorApp.Views.ButtonsV  5    
   $��0��6   $��0��6)   68   #   FlightSimulatorApp.Views.MapV  5!   
   $��0��6   $��1��6%      LonLat 62   �� *
LonLatVM+	 �� Mode$	 OneWay=�6]   5"      5#      