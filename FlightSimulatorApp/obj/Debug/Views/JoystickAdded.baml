   M S B A M L   `   `   `  ����M  IFlightSimulatorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5      ,    &FlightSimulatorApp.Views.JoystickAdded   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:FlightSimulatorApp.Views     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $	��100 �6   �� 5      $	��400 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��2��6!   $��Center=�6.    �� TickPlacement$ BottomRight=�6I    � Maximum$ 1Q�6e    � Minimum$ -1Q�6q    � Value 6~   �� *
RudderVM+ �� Mode$ OneWayToSource=��� 5   
   $��0��6   $��Right=�6!   $ BottomRight=�6=   $ 1Q�6Y   $ 0Q�6e   $��-244,35,2,0.6q�6�   $��2��6�    6q   �� *
ThrottleVM+$ OneWayToSource=� � LayoutTransform 5      V� 5      .~�5      ��  �� Angle$	 270Q�6&   �� 5      	 �� ScaleX$	 -1Q�6%   63   5      5      �� 5    
   $��3��6   $��1��6   $
��Bold"�6-   $��Rudder��6?   $
��Left=�6P   
 J� RenderTransformOrigin$
 0.988,0.494&�6k   $��138,0.4,0,-0.4q�6�   �� 5!   
   $��3��6   $��1��6   $
��Bold"�6-   $��Right=�6i   $��0,0.4,121,-0.4q�6�   $��60��6�   ��6?   �� *
RudderVM+$ OneWay=�6�   �� 5"   
   $��1��6   $��0��6   $
��Bold"�6-   $��Throttle��6?   $��Right=�6R   $��Center=�6n   $��0,98,364,217.6q�6�   $��2��6�   z�5#      �� 5$      $ 90Q�6"   5&      �� 5'   
   $��1��6   $��0��6   $
��Bold"�6-   $��Right=�6k   $��Center=�6�   $��0,188,357,114.6q�6�   $��39��6�   $��66��6�   $��2��6�   ��6?   �� *
ThrottleVM+$ OneWay=�z�5(      �� 5)      $ 90Q�6"   5+      �� 5,   
   $
��Bold"�6   $��1��6"   $��0��62   $��Aileron��6?   $��138,0,142,0q�6Q   �� 5-   
   $
��Bold"�6   $��1��6"   $��0��62   $��
219,0,61,0q�6j   ��6?   �� *	AileronVM+$ OneWay=�6j   �� 5/   
   $
��Bold"�6   $��1��6"   $��2��6/   $��Elevator��6?   $��13,99,14,207.8q�6R   z�50      �� 51      $ 90Q�6"   53      �� 54   
   $
��Bold"�6   $��1��6"   $��2��6/   $��13,179,9,124.6q�6k   ��6?   �� *
ElevatorVM+$ OneWay=�z�55      �� 56      $ 90Q�6"   58      '   !FlightSimulatorApp.Views.Joystick  59   
   -   5          Name$ ManualJoystick��59      $��1��61   $��1��6A      Aileron 5:      �� *	AileronVM+$ OneWayToSource=�   AileronRate 5;      �� *AileronRateVM+$ OneWayToSource=�   Elevator 5<      �� *
ElevatorVM+$ OneWayToSource=�   ElevatorRate 5=      �� *ElevatorRateVM+$ OneWayToSource=�5?      5@      