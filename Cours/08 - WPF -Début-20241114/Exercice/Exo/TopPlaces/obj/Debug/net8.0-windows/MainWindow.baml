   M S B A M L   `   `   `  ����D  @TopPlaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TopPlaces	TopPlaces  5   	       TopPlaces.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TopPlaces     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1058��6)    � 	Resources 5
         
TitreStyle �� Property �� Value  
LabelStyle  ItemTemplate �� Orientation��%  &	        &	 �     &	 �     �� 5   
   .�5      ��  � ��$ 18(�6/   �� 5       � ��
 �   �62   �� 5       � ��$ 2q�66   5      �� 5   
   .�5      ��  � ��$ courrier new)�61   5      �� 5   
   .R�5      �� $ 
Horizontal=�6   $��0 5 0 5q�63   .+�5      �� $��50��6   $��50��6#   $
��Fill=�6/   $��Center=�6W   $��Center=�6r   ��6>   �� *Image+6r   �� 5      $��Center=�68   $��Center=�6S   ��6   �� *Description+6S   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��251* �6   .+�5!   
   �� -   5         ��Name$ listBoxPhotos��5!      #��[ 6)   $��0��6n   $��10q�6~   ��6V   �� 6�   � 5#   
   $��1��6    � RowDefinitions 5$      �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    .+�5-      �� -   5         ��Name$ Titre��5-      $��
Top Places��6#   #��[  68   $��0��6\   $	��100��6i   �� 5.      -   5        	 ��Name$	 image1��5.      $
��Fill=�6$   $	��200��63   $	��300��6@   $��1��6L   $��1��6\   $��Center=�6i   �� 5/      $��Description��6   #��[ 6*   $��1��6N   $��2��6^   $
��Left=�6k   �� 50      $��URI fichier : ��6   #��[ 6-   $��1��6Q   $��3��6a   $
��Left=�6n   �� 51      $��Nb votes : ��6   #��[ 6*   $��1��6N   $��4��6^   $
��Left=�6k   �� 52      -   5        $ description_value��52      $��1��6{   $��2��6�   $
��Left=�6�   ��6/   �� 
 �� ElementName$
 listBoxPhotos�� �� Path$ SelectedItem.Description�6�   �� 53      -   5        $ 	uri_value��53      $��1��6n   $��3��6~   $
��Left=�6�   ��6'   �� $
 listBoxPhotos��$ SelectedItem.GetUri�6�   �� 54      -   5        $ votes_value��54      $��1��6q   $��4��6�   $
��Left=�6�   ��6)   �� $
 listBoxPhotos��$ SelectedItem.NbVotes�6�   57      �� 58   
   -   5        $��30��58      $��378,484,438,58q�6   $��1��6J   $��5��6Z   .��59      �� $ 
Horizontal=�6   $	��113��62   .+�5:      �� $��images\jaime.png��6   $��25��62   $��45��6>   $��0,0,0,0q�6I   $
��Left=�6Z   �� 5;      $��Je vote pour��6   $��Center=�60   $��74��6K   5<      5=      5?      5A      