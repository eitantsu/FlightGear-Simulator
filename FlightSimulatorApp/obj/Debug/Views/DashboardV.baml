   M S B A M L   `   `   `  ����M  IFlightSimulatorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5      )    #FlightSimulatorApp.Views.DashboardV   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:FlightSimulatorApp.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $
��Bold"�6   $��0��6"   $��1��6/   $��indicated-speed-kt��6?   $
��Left=�6\   6y   �� 5   
   $
��Bold"�6   $��0��6"   $��1��6/   $��Right=�6o   ��6?   ��  �� Path$ 	SpeedktVM� �� Mode$ OneWay=�6�   �� 5   
   $
��Bold"�6   $��1��6"   $��1��6/   $��indicated-ground-speed-kt��6?   $
��Left=�6c   6�   �� 5   
   $
��Bold"�6   $��1��6"   $��1��6/   $��Right=�6p   ��6?   �� $ 
GSpeedktVM�$ OneWay=�6�   �� 5   
   $
��Bold"�6   $��2��6"   $��1��6/   $��indicated-vertical-speed��6?   $
��Left=�6b   6   �� 5   
   $
��Bold"�6   $��2��6"   $��1��6/   $��Right=�6n   ��6?   �� $ VSpeedVM�$ OneWay=�6�   �� 5   
   $
��Bold"�6   $��3��6"   $��1��6/   $%��altimeter/indicated-altitude-ft��6?   $
��Left=�6i   6�   �� 5   
   $
��Bold"�6   $��3��6"   $��1��6/   $��Right=�6p   ��6?   �� $ 
MeterAltVM�$ OneWay=�6�   �� 5   
   $
��Bold"�6   $��4��6"   $��1��6/   $��gps/indicated-altitude-ft��6?   $
��Left=�6c   6�   �� 5    
   $
��Bold"�6   $��4��6"   $��1��6/   $��Right=�6n   ��6?   �� $ GpsAltVM�$ OneWay=�6�   �� 5!   
   $
��Bold"�6   $��5��6"   $��1��6/   $��internal-pitch-deg��6?   $
��Left=�6\   6y   �� 5"   
   $
��Bold"�6   $��5��6"   $��1��6/   $��Right=�6m   ��6?   �� $ PitchVM�$ OneWay=�6�   �� 5#   
   $
��Bold"�6   $��6��6"   $��1��6/   $��internal-roll-deg��6?   $
��Left=�6[   6x   �� 5$   
   $
��Bold"�6   $��6��6"   $��1��6/   $��Right=�6l   ��6?   �� $ RollVM�$ OneWay=�6�   �� 5%   
   $
��Bold"�6   $��7��6"   $��1��6/   $��indicated-heading-deg��6?   $
��Left=�6_   6|   �� 5&   
   $
��Bold"�6   $��7��6"   $��1��6/   $��Right=�6o   ��6?   �� $ 	HeadingVM�$ OneWay=�6�   5'      5(      