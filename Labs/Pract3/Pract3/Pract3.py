import networkx as nx
import matplotlib.pyplot as plt
G=nx.Graph()

Uzly=[('A', {'koord':(0,0)}),
 ('B', {'koord':(2,1)}),
 ('C', {'koord':(0,6)}),
 ('D', {'koord':(6,4)}),
 ('E', {'koord':(3,9)}),
 ('F', {'koord':(7,0)}),
 ('G', {'koord':(2,5)}),
 ('H', {'koord':(8,7)})
]

Dlina=[('A', 'B', {'length':2}),
 ('B', 'C', {'length':6}),
 ('A', 'C', {'length':7}),
 ('B', 'D', {'length':5}),
 ('E', 'G', {'length':4}),
 ('E', 'C', {'length':9}),
 ('F', 'H', {'length':5}),
 ('C', 'H', {'length':15}),
 ('D', 'F', {'length':4}),
 ('D', 'G', {'length':3}),
 ('G', 'H', {'length':10}),
 ('G', 'B', {'length':2})
]

G.add_nodes_from(Uzly)
G.add_edges_from(Dlina)

pos = nx.get_node_attributes(G, 'koord')

labels = nx.get_edge_attributes(G,'length')

nx.draw_networkx(
        G,
        pos,
        node_size = [800, 800, 800, 800, 800, 800, 800, 800],
        font_size=20,
        with_labels=True,
        node_color='y')

nx.draw_networkx_edge_labels(
        G,
        pos,
        font_size=16,
        edge_labels=labels)

print('кратчайший путь между вершинами E и F = ',
      nx.shortest_path(G, 'E', 'F', weight='length'))
print('длина кратчайшего пути между вершинами E и F = ',
      nx.shortest_path_length(G,'E', 'F',weight='length'))
ax = plt.gca()
ax.margins(0.1)
plt.axis("off")

plt.show()
