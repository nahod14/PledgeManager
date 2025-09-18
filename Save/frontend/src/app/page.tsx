import Image from "next/image";

export default function Home() {
  return (
    <main className="min-h-screen p-8">
      <div className="max-w-4xl mx-auto">
        <h1 className="text-4xl font-bold mb-8">Product Price Tracker</h1>
        
        <div className="bg-white rounded-lg shadow-md p-6">
          <h2 className="text-2xl font-semibold mb-4">Track Your Products</h2>
          <p className="text-gray-600 mb-6">
            Monitor prices across multiple e-commerce websites and get notified when prices drop.
          </p>
          
          <div className="space-y-4">
            <div className="flex gap-4">
              <input
                type="text"
                placeholder="Enter product URL"
                className="flex-1 p-2 border rounded-md"
              />
              <button className="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600">
                Track Product
              </button>
            </div>
          </div>
        </div>

        <div className="mt-8 grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="bg-white rounded-lg shadow-md p-6">
            <h3 className="text-xl font-semibold mb-4">Features</h3>
            <ul className="space-y-2 text-gray-600">
              <li>• Track prices from multiple stores</li>
              <li>• Get price drop notifications</li>
              <li>• View price history charts</li>
              <li>• Set price alerts</li>
            </ul>
          </div>
          
          <div className="bg-white rounded-lg shadow-md p-6">
            <h3 className="text-xl font-semibold mb-4">Supported Stores</h3>
            <ul className="space-y-2 text-gray-600">
              <li>• Amazon</li>
              <li>• AliExpress</li>
              <li>• Walmart</li>
              <li>• More coming soon...</li>
            </ul>
          </div>
        </div>
      </div>
    </main>
  );
}
